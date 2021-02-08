using FreelanceTK.Domain.Entities.Identity;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace FreelanceTK.Infrastructure.Identity.Identity.Extensions
{
    public static class ServiceCollectionsExtension
    {
        public static void AddIdentityServer4(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, IdentityFreelanceTKDbContext>(options => ConfigureApiAuthorization(options, configuration))
                .AddProfileService<DefaultProfileService>();

            var tokenValidIssuers = configuration.GetSection($"IdentityServer:TokenValidationParameters:ValidIssuers").Get<string[]>();

            services.AddAuthentication().AddGoogle(config =>
            {
                config.ClientId = configuration.GetSection("Authentication:Google")["ClientId"];
                config.ClientSecret = configuration.GetSection("Authentication:Google")["ClientSecret"];
            })
                .AddFacebook(config =>
                {
                    config.ClientId = configuration.GetSection("Authentication:Facebook")["ClientId"];
                    config.ClientSecret = configuration.GetSection("Authentication:Facebook")["ClientSecret"];
                })
                .AddMicrosoftAccount(config =>
                {
                    config.ClientId = configuration.GetSection("Authentication:Microsoft")["ClientId"];
                    config.ClientSecret = configuration.GetSection("Authentication:Microsoft")["ClientSecret"];
                }).AddIdentityServerJwt();

        }

        private static void ConfigureApiAuthorization(ApiAuthorizationOptions options, IConfiguration configuration)
        {
            ConfigureClients(options.Clients, configuration);

            ConfigureApiResources(options.ApiResources);

        }

        private static void ConfigureApiResources(ApiResourceCollection apiResources)
        {
            var apiResource = apiResources.First();
            //apiResource.UserClaims = new string[] { EmployeeClaimTypes.UserIdentifier };
        }

        private static void ConfigureClients(ClientCollection clients, IConfiguration configuration)
        {
            foreach (var client in clients)
            {
                client.AllowOfflineAccess = true;
                client.AccessTokenLifetime = (int)TimeSpan.FromHours(8).TotalSeconds;
            }
        }


    }
}
