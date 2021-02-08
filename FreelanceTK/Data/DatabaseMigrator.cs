using FreelanceTK.Infrastructure.Identity;
using FreelanceTK.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FreelanceTK.Data
{
    public class DatabaseMigrator
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IdentityFreelanceTKDbContext identityFreelanceTKDbContext;
        public DatabaseMigrator(ApplicationDbContext dbContext, IdentityFreelanceTKDbContext identityFreelanceTKDbContext)
        {
            this.dbContext = dbContext;
            this.identityFreelanceTKDbContext = identityFreelanceTKDbContext;
        }

        public async Task MigrateAsync()
        {
            await identityFreelanceTKDbContext.Database.MigrateAsync();
            await dbContext.Database.MigrateAsync();
        }
    }
}
