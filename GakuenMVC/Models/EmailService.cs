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
using System.IO;
using System.Net.Mail;

using RestSharp;
using RestSharp.Authenticators;

namespace GakuenMVC.Models
{
    public class EmailService
    {
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
}
