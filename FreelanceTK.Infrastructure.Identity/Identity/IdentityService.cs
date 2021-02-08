using FluentValidation.Results;
using FreelanceTK.Application.Common.Exceptions;
using FreelanceTK.Application.Common.Interfaces;
using FreelanceTK.Domain.Common;
using FreelanceTK.Domain.Entities.Identity;
using FreelanceTK.Infrastructure.Identity.Identity.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FreelanceTK.Infrastructure.Identity.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<IdentityService> logger;
        public IdentityService(UserManager<ApplicationUser> userManager, ILogger<IdentityService> logger)
        {
            this.userManager = userManager;
            this.logger = logger;
        }

        public async Task<string> CreateUserAsync(string userName, string email, string password, bool needChangePassword = true, CancellationToken cancellationToken = default)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = email,
                EmailConfirmed = !string.IsNullOrEmpty(email),
                Created = SystemTime.Now()
            };
            var result = await userManager.CreateAsync(user, password);
            result.ThrowExceptionIfNotSuccess();

            return user.Id;
        }

        public async Task AddToClaimAsync(string userId, string claimType, string claimValue, CancellationToken cancellationToken = default)
        {
            var user = await userManager.FindByIdAsync(userId);
            ThrowExceptionIfNull(userId, user);
            var claims = await userManager.GetClaimsAsync(user);
            if (!claims.Any(p => p.Type == claimType))
            {
                var result = await userManager.AddClaimAsync(user, new Claim(claimType, claimValue));
                result.ThrowExceptionIfNotSuccess();
            }
        }

        public async Task AddToClaimAsync(string userId, string claimType, int claimValue, CancellationToken cancellationToken = default)
        {
            await AddToClaimAsync(userId, claimType, claimValue.ToString(), cancellationToken);
        }

        public async Task ChangeUserPassword(string userId, string newPassword, CancellationToken cancellationToken = default)
        {
            var user = await userManager.FindByIdAsync(userId);
            ThrowExceptionIfNull(userId, user);
            var result = await userManager.RemovePasswordAsync(user);
            result.ThrowExceptionIfNotSuccess();
            var setPasswordResult = await userManager.AddPasswordAsync(user, newPassword);
            setPasswordResult.ThrowExceptionIfNotSuccess();
        }

        public async Task<(DateTimeOffset? lockoutEnd, bool isLockedout, bool isEnabled)> GetLockoutInfo(string userId, CancellationToken cancellationToken = default)
        {
            var user = await userManager.FindByIdAsync(userId);
            ThrowExceptionIfNull(userId, user);
            return (user.LockoutEnd, user.LockoutEnabled && user.LockoutEnd > SystemTime.Now(), user.LockoutEnabled);
        }

        public async Task LockUserAsync(string userId, DateTimeOffset? until, CancellationToken cancellationToken = default)
        {
            var user = await userManager.FindByIdAsync(userId);
            ThrowExceptionIfNull(userId, user);
            var result = await userManager.SetLockoutEnabledAsync(user, true);
            result.ThrowExceptionIfNotSuccess();
            var lockResult = await userManager.SetLockoutEndDateAsync(user, until);
            lockResult.ThrowExceptionIfNotSuccess();
        }

        public async Task SetConfirmedEmailAsync(string userId, string email)
        {
            var user = await userManager.FindByIdAsync(userId);
            ThrowExceptionIfNull(userId, user);
            user.Email = email;
            user.EmailConfirmed = true;
            var result = await userManager.UpdateAsync(user);
            result.ThrowExceptionIfNotSuccess();
        }

        public async Task UnlockUserAsync(string userId, CancellationToken cancellationToken = default)
        {
            var user = await userManager.FindByIdAsync(userId);
            ThrowExceptionIfNull(userId, user);
            var result = await userManager.SetLockoutEndDateAsync(user, DateTimeOffset.Now.AddDays(-1));
            result.ThrowExceptionIfNotSuccess();
            logger.LogInformation($"{user.UserName} is unlocked");
        }

        public async Task UpdateLockoutInfo(string userId, DateTimeOffset? until, bool lockoutEnabled, CancellationToken cancellationToken = default)
        {
            var user = await userManager.FindByIdAsync(userId);
            ThrowExceptionIfNull(userId, user);
            var result = await userManager.SetLockoutEnabledAsync(user, lockoutEnabled);
            result.ThrowExceptionIfNotSuccess();

            logger.LogInformation($"For {user.UserName} lockout is enabled: {lockoutEnabled}.");

            if (lockoutEnabled)
            {
                var lockResult = await userManager.SetLockoutEndDateAsync(user, until);
                lockResult.ThrowExceptionIfNotSuccess();

                logger.LogInformation($"{user.UserName} is locked till {until}.");
            }
        }

        public async Task UpdateUsernameAsync(string userId, string userName)
        {
            var user = await userManager.FindByIdAsync(userId);
            ThrowExceptionIfNull(userId, user);
            var result = await userManager.SetUserNameAsync(user, userName);
            result.ThrowExceptionIfNotSuccess();
        }

        private static void ThrowExceptionIfNull(string userId, ApplicationUser user)
        {
            if (user == null)
            {
                throw new NotFoundException(nameof(ApplicationUser), userId);
            }
        }
    }
}
