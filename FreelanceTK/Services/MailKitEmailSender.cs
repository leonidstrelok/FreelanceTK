using FreelanceTK.Application.Common.Interfaces;
using FreelanceTK.Application.Common.Models;
using FreelanceTK.Options;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FreelanceTK.Services
{
    /// <summary>
    /// Сервис для отправки сообщений на почту
    /// </summary>
    public class MailKitEmailSender : IEmailSender
    {
        private readonly EmailOptions emailOptions;

        public MailKitEmailSender(IOptions<EmailOptions> emailOptions)
        {
            this.emailOptions = emailOptions.Value;
        }

        public async Task SendEmailAsync(Email emailMessage, CancellationToken cancellationToken = default)
        {
            var emailBody = new BodyBuilder
            {
                HtmlBody = emailMessage.Message
            };

            if (emailMessage.Attachments != null)
            {
                foreach (var attachment in emailMessage.Attachments)
                {
                    using var ms = new MemoryStream();
                    attachment.Data.CopyTo(ms);
                    var fileBytes = ms.ToArray();

                    emailBody.Attachments.Add(attachment.Name, fileBytes);
                }
            }

            var mimeMessage = MimeMessage(emailMessage.EmailTo, emailMessage.Subject);

            mimeMessage.Body = emailBody.ToMessageBody();

            await Send(mimeMessage);
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var mimeMessage = MimeMessage(email, subject);

            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            { Text = htmlMessage };

            await Send(mimeMessage);
        }

        private MimeMessage MimeMessage(string email, string subject)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(MailboxAddress.Parse(emailOptions.Sender));
            mimeMessage.To.Add(MailboxAddress.Parse(email));
            mimeMessage.Subject = subject;


            return mimeMessage;
        }

        private async Task Send(MimeMessage mimeMessage)
        {
            using SmtpClient smtpClient = new SmtpClient();

            smtpClient.ServerCertificateValidationCallback += (s, c, h, e) => true;
            await smtpClient.ConnectAsync(emailOptions.SmtpServer, emailOptions.Port, emailOptions.UseSsl);
            await smtpClient.AuthenticateAsync(emailOptions.UserName, emailOptions.Password);
            await smtpClient.SendAsync(mimeMessage);
            await smtpClient.DisconnectAsync(true);
        }
    }
}
