using System;
using Strategy_Pattern_First_Look.Business.Models;
using Strategy_Pattern_First_Look.Business.Strategies.Invoice;
using Strategy_Pattern_First_Look.Business.Strategies.SalesTax;
using Strategy_Pattern_First_Look.Business.Strategies.Shipping;

namespace Strategy_Pattern_First_Look
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Input
            Console.WriteLine("Please select an origin country:");
            var origin = Console.ReadLine().Trim();
            
            Console.WriteLine("Please select a destination country: ");
            var destination = Console.ReadLine().Trim();
            
            Console.WriteLine("Choose one of the following shipping providers.");
            Console.WriteLine("1. PostNord (Swedish Postal Service)");
            Console.WriteLine("2. DHL");
            Console.WriteLine("3. Fedex");
            
            Console.WriteLine("Select shipping provider: ");
            var provider = Convert.ToInt32(Console.ReadLine().Trim());
            
            Console.WriteLine("Choose one of the following invoice delivery options.");
            Console.WriteLine("1. E-mail");
            Console.WriteLine("2. File (download later)");
            Console.WriteLine("3. Mail");
            Console.WriteLine("Select invoice delivery options: ");
            var invoiceOption = Convert.ToInt32(Console.ReadLine().Trim());
            

            #endregion
            var order = new Order
            {
                ShippingDetails = new ShippingDetails
                {
                    OriginCountry = origin,
                    DestinationCountry = destination
                },
                SalesTaxStrategy = GetSalesTaxStrategyFor(origin),
                InvoiceStrategy = GetInvoiceStrategy(invoiceOption),
                ShippingStrategy = GetShippingStrategyFor(provider)
            };

            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m, ItemType.Literature), 1);
            order.LineItems.Add(new Item("CONSULTING", "Building a website", 100m, ItemType.Service), 1);
            
            order.SelectedPayments.Add(new Payment
            {
                PaymentProvider = PaymentProvider.Invoice
            });
            
            Console.WriteLine(order.GetTax());

            order.FinalizeOrder();
        }

        private static ISalesTaxStrategy GetSalesTaxStrategyFor(string origin)
        {
            if (origin.ToLowerInvariant() == "sweden")
            {
                return new SwedenSalesTaxStrategy();
            }
            else if (origin.ToLowerInvariant() == "usa")
            {
                return new USAStateSalesTaxStrategy();
            }
            else
            {
                throw new Exception("Unsupported shipping region");
            }
        }

        private static IInvoiceStrategy GetInvoiceStrategy(in int option)
        {
            switch (option)
            {
                case 1: return new EmailInvoiceStrategy();
                case 2: return new FileInvoiceStrategy();
                case 3: return new PrintOnDemandInvoiceStrategy();
                default: throw new Exception("Unsupported invoice delivery option");

            } 
        }

        private static IShippingStrategy GetShippingStrategyFor(in int provider)
        {
            switch (provider)
            {
                case 1: return new SwedishPostalServiceShippingStrategy();
                case 2: return new DhlShippingStrategy();
                case 3: return new FedexShippingStrategy();
                default: throw new Exception("Unsupported shipping method");

            }
        }
    }
}