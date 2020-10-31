namespace DreamAIMusic.Services.Messaging
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEmailSender
    {
        Task SendEmailAsync(
            string toMail,
            string subject,
            string messageBody);

        Task SendEmailAfterUserRegistration(
            string to,
            string username,
            string password);
    }
}
