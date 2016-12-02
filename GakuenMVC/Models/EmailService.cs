using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Net;
using System.Configuration;
using System.Diagnostics;
using System.Security.Cryptography;
using SendGrid;
using System.IO;
using System.Net.Mail;
using RestSharp;
using RestSharp.Authenticators;

namespace GakuenMVC.Models
{
    public class EmailService
    {
        //Version 1
        //public async Task SendAsync(IdentityMessage message)
        //{
        //    await ConfigSmtpAsync(message);
        //}

        //private async Task ConfigSmtpAsync(IdentityMessage message)
        //{
        //    var myMessage = new SendGrid.Get
        //    myMessage.AddTo(message.Destination);
        //    myMessage.From = new System.Net.Mail.MailAddress(
        //                        "Joe@contoso.com", "Joe S.");
        //    myMessage.Subject = message.Subject;
        //    myMessage.Text = message.Body;
        //    myMessage.Html = message.Body;

        //    var credentials = new NetworkCredential(
        //               ConfigurationManager.AppSettings["mailAccount"],
        //               ConfigurationManager.AppSettings["mailPassword"]
        //               );

        //    // Create a Web transport for sending email.
        //    var transportWeb = new Web(credentials);

        //    // Send the email.
        //    if (transportWeb != null)
        //    {
        //        await transportWeb.DeliverAsync(myMessage);
        //    }
        //    else
        //    {
        //        Trace.TraceError("Failed to create Web transport.");
        //        await Task.FromResult(0);
        //    }
        //}

        //Version 2
        //public static string GenerateEmailToken()
        //{
        //    // generate an email verification token for the user
        //    using (RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider())
        //    {
        //        byte[] data = new byte[16];
        //        provider.GetBytes(data);
        //        return Convert.ToBase64String(data);
        //    }
        //}

        //Version 3
        //public void SendIt()
        //{
        //    var msg = new AE.Net.Mail.MailMessage
        //    {
        //        Subject = "Your Subject",
        //        Body = "Hello, World, from Gmail API!",
        //        From = new MailAddress("gakuenreply@gmail.com")
        //    };

        //    msg.To.Add(new MailAddress("martin1-g@hotmail.com"));
        //    msg.ReplyTo.Add(msg.From); // Bounces without this!!
        //    var msgStr = new StringWriter();
        //    msg.Save(msgStr);

        //    var gmail = new GmailService(GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets {ClientId = }));
        //    var result = gmail.Users.Messages.Send(new Message
        //    {
        //        Raw = Base64UrlEncode(msgStr.ToString())
        //    }, "me").Execute();
        //    Console.WriteLine("Message ID {0} sent.", result.Id);
        //}

        //private static string Base64UrlEncode(string input)
        //{
        //    var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
        //    // Special "url-safe" base64 encode.
        //    return Convert.ToBase64String(inputBytes)
        //      .Replace('+', '-')
        //      .Replace('/', '_')
        //      .Replace("=", "");
        //}

        
        //Version 5
        public static RestResponse SendSimpleMessage()
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                   new HttpBasicAuthenticator("api",
                                              "key-8782ae44040d98f33c87a175376e0632");
            RestRequest request = new RestRequest();
            request.AddParameter("domain",
                                "sandbox58007e700f024722a5e7a7226024d8f2.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Mailgun Sandbox <postmaster@sandbox58007e700f024722a5e7a7226024d8f2.mailgun.org>");
            request.AddParameter("to", "GakuenEsbjerg <gakuenreply@gmail.com>");
            request.AddParameter("subject", "Hello GakuenEsbjerg");
            request.AddParameter("text", "Congratulations GakuenEsbjerg, you just sent an email with Mailgun!  You are truly awesome!  You can see a record of this email in your logs: https://mailgun.com/cp/log .  You can send up to 300 emails/day from this sandbox server.  Next, you should add your own domain so you can send 10,000 emails/month for free.");
            request.Method = Method.POST;
            return client.Execute(request) as RestResponse;
        }
    }
}
