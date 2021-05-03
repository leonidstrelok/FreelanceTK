using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using FluentValidation;
using FreelanceTK.Application;
using FreelanceTK.Application.Common.Interfaces;
using FreelanceTK.Infrastructure.Identity;
using FreelanceTK.Infrastructure.Localization;
using FreelanceTK.Infrastructure.Persistence;
using FreelanceTK.Options;
using FreelanceTK.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using DependencyInjection = FreelanceTK.Application.DependencyInjection;

namespace FreelanceTK
{
    public class Startup
    {
        private const string AllowedDomainsCorsPolicy = "AllowedDomains";
        private IWebHostEnvironment Env { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IEmailSender, MailKitEmailSender>();
            services.Configure<EmailOptions>(Configuration.GetSection("EmailOptions"));

            services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);


            services.AddRazorPages()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

            services.AddApplication()
                .AddPersistence(Configuration)
                .AddIdentity(Configuration)
                .AddFLTKLocalization();

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(context =>
                {
                    if (context.Request.Path.StartsWithSegments("/api"))
                    {
                        return new AcceptLanguageHeaderRequestCultureProvider().DetermineProviderCultureResult(context);
                    }

                    return new CookieRequestCultureProvider().DetermineProviderCultureResult(context);
                }));

                var tkCulture = new CultureInfo("tk");
                tkCulture.NumberFormat.NumberDecimalSeparator = ".";
                tkCulture.NumberFormat.CurrencyGroupSeparator = ".";
                var ruCulture = new CultureInfo("ru");
                tkCulture.NumberFormat.NumberDecimalSeparator = ".";
                tkCulture.NumberFormat.CurrencyGroupSeparator = ".";
                var enCulture = new CultureInfo("en");
                tkCulture.NumberFormat.NumberDecimalSeparator = ".";
                tkCulture.NumberFormat.CurrencyGroupSeparator = ".";

                var supportedCultures = new List<CultureInfo>
                {
                    tkCulture,
                    ruCulture,
                    enCulture
                };

                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.SetDefaultCulture("ru");
            });

            services.Configure<IdentityOptions>(Configuration.GetSection("IdentityOptions"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "FreelanceTK", Version = "v1"});
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.EnableAnnotations();
            });

            services.AddCors(ConfigureCors);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/error-local-development");
                app.UseForwardedHeaders();
            }
            else
            {
                app.UseExceptionHandler("/error-production");
                app.UseForwardedHeaders();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TDS v1");
                c.EnableFilter();
            });


            app.UseRouting();

            app.UseCors(AllowedDomainsCorsPolicy);

            app.UseRequestLocalization();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireAuthorization();
                endpoints.MapRazorPages().RequireAuthorization();
            });
        }

        private void ConfigureCors(CorsOptions options)
        {
            options.AddPolicy(AllowedDomainsCorsPolicy, builder =>
            {
                var tokenValidIssuers = new List<string>(Configuration
                    .GetSection("IdentityServer:TokenValidationParameters:ValidIssuers").Get<string[]>());
                if (Env.IsDevelopment()) tokenValidIssuers.Add("http://localhost:3000");

                builder.WithOrigins(tokenValidIssuers.ToArray()).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
            });
        }
    }
}