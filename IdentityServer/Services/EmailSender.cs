using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace IdentityServer.Services
{
    public class EmailSender : IEmailSender
    {
        
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            await Execute(subject, htmlMessage, email);
        }

        public async Task Execute( string subject, string message, string email)
        {
            var mailSender = new AuthMessageSenderOptions();
            var client = new SendGridClient(mailSender.SendGridKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("hung1pham2603@gmail.com", mailSender.SendGridUser),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            await client.SendEmailAsync(msg);
        }

    }
}
