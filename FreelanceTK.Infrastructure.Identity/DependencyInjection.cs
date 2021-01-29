using FreelanceTK.Infrastructure.Identity.Identity.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FreelanceTK.Infrastructure.Identity
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityFreelanceTKDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });


            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityFreelanceTKDbContext>()
                .AddDefaultTokenProviders();


            services.AddIdentityServer()
                .AddApiAuthorization<IdentityUser, IdentityFreelanceTKDbContext>();

            services.AddAuthentication()
                .AddGoogle();

            services.AddIdentityServer4(configuration);

            return services;
        }
    }
}
