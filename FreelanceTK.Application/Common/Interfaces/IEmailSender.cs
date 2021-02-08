using FreelanceTK.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FreelanceTK.Application.Common.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Email emailMessage, CancellationToken cancellationToken = default);
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
