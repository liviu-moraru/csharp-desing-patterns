using System.Net;
using System.Net.Mail;
using Strategy_Pattern_First_Look.Business.Models;

namespace Strategy_Pattern_First_Look.Business.Strategies.Invoice
{
    public class EmailInvoiceStrategy : InvoiceStrategy
    {
        public override void Generate(Order order)
        {
            var body = GenerateTextInvoice(order);
            using (SmtpClient client = new SmtpClient("smtp.sendgrid.net", 587))
            {
                NetworkCredential credentials = new NetworkCredential("liviu.moraru@gmail.com", "cFwhv-1rHJsL");
                client.Credentials = credentials;

                MailMessage mail = new MailMessage("liviu.moraru@cegeka.com", "liviu.moraru@gmail.com")
                {
                    Subject = "We've created an invoice for your order",
                    Body = body,
                };

                client.Send(mail);
            }
        }
    }
}