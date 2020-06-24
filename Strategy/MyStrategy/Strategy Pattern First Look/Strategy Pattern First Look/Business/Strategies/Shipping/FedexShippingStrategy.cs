using System;
using System.Net.Http;
using Strategy_Pattern_First_Look.Business.Models;

namespace Strategy_Pattern_First_Look.Business.Strategies.Shipping
{
    public class FedexShippingStrategy : IShippingStrategy
    {
        public void Ship(Order order)
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine("Order is shipped with Fedex");
            }
        }
    }
}