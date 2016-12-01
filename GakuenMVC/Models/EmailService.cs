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
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using mailinblue;

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

        //Version 4
        //public void SendMessage()
        //{
        //    API sendinBlue = new mailinblue.API("L2tHk6ZE7g5K9F4M");
        //    Dictionary<string, object> data = new Dictionary<string, object>();
        //    List<int> listid = new List<int>();
        //    listid.Add(2);
        //    listid.Add(7);
        //    data.Add("html_content", "Congratulations ! You successfully sent this example campaign via the SendinBlue API.");
        //    data.Add("name", "Campaign sent via the API");
        //    data.Add("subject", "My subject");
        //    data.Add("from_name", "From name");
        //    data.Add("to", "martin1-g@hotmail.com");
        //    data.Add("from_email", "gakuenreply@gmail.com");
        //    data.Add("listid", listid);
        //    data.Add("scheduled_date", "2015-01-01 00:00:01");

        //    Object createCampaign = sendinBlue.create_campaign(data);
        //    Console.WriteLine(createCampaign);
        //}
    }
}
