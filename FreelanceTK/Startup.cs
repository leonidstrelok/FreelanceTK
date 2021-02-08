using FreelanceTK.Application;
using FreelanceTK.Application.Common.Interfaces;
using FreelanceTK.Extensions;
using FreelanceTK.Infrastructure.Identity;
using FreelanceTK.Infrastructure.Localization;
using FreelanceTK.Infrastructure.Persistence;
using FreelanceTK.Options;
using FreelanceTK.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FreelanceTK
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IEmailSender, MailKitEmailSender>();
            services.Configure<EmailOptions>(Configuration.GetSection("EmailOptions"));

            services.AddRequestLocalization();

            services.AddControllers();
            services.AddApplication()
                .AddPersistence(Configuration)
                .AddIdentity(Configuration)
                .AddLocalication();

            services.AddSwagger();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseRequestLocalization();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
