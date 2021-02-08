using Microsoft.AspNetCore.Identity;
using System;

namespace FreelanceTK.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
