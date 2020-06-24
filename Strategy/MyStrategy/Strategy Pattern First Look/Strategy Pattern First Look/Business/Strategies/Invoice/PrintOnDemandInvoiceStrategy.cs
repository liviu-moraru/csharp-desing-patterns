using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Strategy_Pattern_First_Look.Business.Models;

namespace Strategy_Pattern_First_Look.Business.Strategies.Invoice
{
    public class PrintOnDemandInvoiceStrategy : IInvoiceStrategy
    {
        public void Generate(Order order)
        {
            using (var client = new HttpClient())
            {
                var content = JsonSerializer.Serialize(order);
                client.BaseAddress = new Uri("https://pluralsight.com");
                client.PostAsync("/print-on-demand", new StringContent(content));
            }
        }
    }
}