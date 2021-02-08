using FreelanceTK.Application.Common.Constants;
using FreelanceTK.Application.Common.Interfaces;
using FreelanceTK.Infrastructure.Localization.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceTK.Infrastructure.Localization
{
    public class LocalizationService : ILocalizationService
    {
        public string this[string key] => GetResource(key);

        public string GetResource(string key)
        {
            return Messages.ResourceManager.GetString(key) ?? key;
        }

        public string StatusMustBeActive => GetResource(LocalizationKeys.SharedKeys.StatusMustBeActive);
        public string CascadeDependencyError => GetResource(LocalizationKeys.SharedKeys.CascadeDependencyError);
        public string ValueAlreadyExists => GetResource(LocalizationKeys.SharedKeys.ValueAlreadyExists);
    }
}
