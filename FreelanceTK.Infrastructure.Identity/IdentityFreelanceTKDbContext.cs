using FreelanceTK.Domain.Entities.Identity;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FreelanceTK.Infrastructure.Identity
{
    public class IdentityFreelanceTKDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public IdentityFreelanceTKDbContext(DbContextOptions<IdentityFreelanceTKDbContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
    }
}
