using FreelanceTK.Application.Common.Static;
using FreelanceTK.Domain.Common;
using FreelanceTK.Domain.Entities.Identity;
using FreelanceTK.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceTK.Data
{
    public class DataSeeder
    {
        private readonly ILogger<DataSeeder> logger;
        private readonly ApplicationDbContext dbContext;
        private readonly IConfiguration configuration;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public DataSeeder(
            ApplicationDbContext dbContext,
            ILogger<DataSeeder> logger,
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.configuration = configuration;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task SeedData()
        {
            await dbContext.Database.MigrateAsync();


            await InitAdmin();
        }

        private async Task InitAdmin()
        {
            if (!userManager.Users.Any(p => p.UserName == "Admin"))
            {
                var user = new ApplicationUser
                {
                    UserName = "Admin",
                    Email = "admin@gmail.com",
                    Created = SystemTime.Now()
                };

                foreach (var role in Roles.LIST)
                {
                    if (await roleManager.FindByNameAsync(role) == null)
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }

                var result = await userManager.CreateAsync(user, "Password1!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Roles.ADMIN);
                }

            }
        }
    }
}
