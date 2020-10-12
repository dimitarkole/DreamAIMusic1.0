namespace DreamAIMusic.Services.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mail;
    using System.Threading.Tasks;

    using SendGrid;
    using SendGrid.Helpers.Mail;

    using static DreamAIMusic.Common.GlobalConstants;

    public class SendGridEmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string toMail, string subject, string messageBody, string token)
        {
            // Create smtp connection.
            SmtpClient client = new SmtpClient();

            // outgoing port for the mail.
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(SystemEmail, SystemEmailPassword);

            // Fill the mail form.
            var send_mail = new MailMessage();
            send_mail.IsBodyHtml = true;

            // address from where mail will be sent.
            send_mail.From = new MailAddress(SystemEmail);

            // address to which mail will be sent.
            send_mail.To.Add(new MailAddress(toMail));

            // subject and body of the mail.
            send_mail.Subject = subject;
            send_mail.Body = messageBody;

            client.SendAsync(send_mail, token);
        }

        public async Task SendEmailAfterUserRegistration(string to, string username, string password, string token)
        {
            var subject = "Successful registration";
            var htmlContent = "username: " + username + "\n" + "password: " + password;
            await this.SendEmailAsync(to, subject, htmlContent, token);
        }
    }
}
