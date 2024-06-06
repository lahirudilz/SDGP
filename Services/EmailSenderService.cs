using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace susFaceGen.Services
{
    public class EmailSenderService : IEmailSender
    {
        private readonly ISendGridClient _sendGridClient;
        private readonly SendGridConfiguration _sendGridConfiguration;

        public EmailSenderService(ISendGridClient sendGridClient, IOptions<SendGridConfiguration> sendGridConfiguration)
        {
            _sendGridClient = sendGridClient;
            _sendGridConfiguration = sendGridConfiguration.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new SendGridMessage()
            {
                From = new EmailAddress(_sendGridConfiguration.FromEmail, _sendGridConfiguration.EmailName),
                Subject = subject,
                HtmlContent = htmlMessage
            };

            message.AddTo(email);
            await _sendGridClient.SendEmailAsync(message);
        }
    }
}
