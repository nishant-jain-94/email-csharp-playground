using System;
using MailKit.Net.Smtp;
using MimeKit;

namespace EmailCsharpMailKit
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = new MimeMessage ();
			message.From.Add (new MailboxAddress ("Team Proflo", "<<FromAddress>>"));
			message.To.Add (new MailboxAddress ("Nishant Jain", "<<ToAddress>>"));
			message.Subject = "Application for the role of Software Engineer";
			message.Body = new TextPart ("plain") {
				Text = @"Hey Chandler,
                I just wanted to let you know that Monica and I were going to go play some paintball, you in?
                -- Joey"
			};
			using (var client = new SmtpClient ()) 
            {
				// For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
				client.ServerCertificateValidationCallback = (s,c,h,e) => true;
				client.Connect ("in-v3.mailjet.com", 587, false);
				// Note: only needed if the SMTP server requires authentication
				client.Authenticate (Environment.GetEnvironmentVariable("APIKey"), Environment.GetEnvironmentVariable("SecretKey"));
				client.Send (message);
				client.Disconnect (true);
			}
        }
    }
}
