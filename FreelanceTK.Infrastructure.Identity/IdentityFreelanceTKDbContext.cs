using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceTK.Infrastructure.Identity
{
    public class IdentityFreelanceTKDbContext : ApiAuthorizationDbContext<IdentityUser>
    {
        public IdentityFreelanceTKDbContext(DbContextOptions<IdentityFreelanceTKDbContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
    }
}
