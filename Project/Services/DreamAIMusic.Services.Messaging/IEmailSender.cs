namespace DreamAIMusic.Services.Messaging
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEmailSender
    {
        Task SendEmailAsync(
            string toMail,
            string subject,
            string messageBody,
            string token);

        Task SendEmailAfterUserRegistration(
            string to,
            string username,
            string password,
            string token);
    }
}
