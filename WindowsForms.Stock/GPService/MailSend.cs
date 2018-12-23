using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsForms.Stock.GPService
{
    public class MailSend
    {
        public static void SendEmail(string Content) {

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("liwh.163", "liwenhai0745@163.com"));
            message.To.Add(new MailboxAddress("liwh", "624302265@QQ.com"));

            message.Subject = "GP_INFO";

            message.Body = new TextPart("plain") { Text = Content };

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.163.com", 465, true);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("liwenhai0745@163.com", "Liwenhai0745");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
