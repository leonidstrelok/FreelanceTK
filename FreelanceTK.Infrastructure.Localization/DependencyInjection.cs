using FluentValidation;
using FreelanceTK.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FreelanceTK.Infrastructure.Localization
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFLTKLocalization(this IServiceCollection services)
        {
            services.AddSingleton<ILocalizationService, LocalizationService>();
            ValidatorOptions.Global.LanguageManager = new TurkmenLanguageManager();
            return services;
        }
    }
}