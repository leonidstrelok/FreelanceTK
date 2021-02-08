using FluentValidation.Results;
using FreelanceTK.Application.Common.Exceptions;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace FreelanceTK.Infrastructure.Identity.Identity.Extensions
{
    public static class UserManagerExtensions
    {
        public static void ThrowExceptionIfNotSuccess(this IdentityResult identityResult)
        {
            if (!identityResult.Succeeded)
            {
                throw new ValidationException(identityResult.Errors.Select(prop => new ValidationFailure(prop.Code, prop.Description)));
            }
        }

    }
}
