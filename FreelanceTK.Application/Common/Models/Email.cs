using System.Collections.Generic;

namespace FreelanceTK.Application.Common.Models
{
    /// <summary>
    /// Почта
    /// </summary>
    public class Email
    {
        public Email(string to, string subject)
        {
            EmailTo = to;
            Subject = subject;
            Attachments = new List<EmailAttachments>();
        }

        public string EmailTo { get; }
        public string Subject { get; }
        public string Message { get; set; }
        public List<EmailAttachments> Attachments { get; }
    }
}
