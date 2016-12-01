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
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;

namespace GakuenMVC.Models
{
    public class EmailService
    {
        //public async Task SendAsync(IdentityMessage message)
        //{
        //    await ConfigSmtpAsync(message);
        //}

        //private async Task ConfigSmtpAsync(IdentityMessage message)
        //{
        //    var myMessage = new SendGrid();
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

        public static string GenerateEmailToken()
        {
            // generate an email verification token for the user
            using (RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[16];
                provider.GetBytes(data);
                return Convert.ToBase64String(data);
            }
        }
    }

    public class CreateAccountResponse
    {
        public bool CreatedSuccessfully { get; set; }

        public string EmailVerificationToken { get; set; }
    }
}
