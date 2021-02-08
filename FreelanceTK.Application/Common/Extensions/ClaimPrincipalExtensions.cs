using FreelanceTK.Application.Common.Constants;
using System.Security.Claims;

namespace FreelanceTK.Application.Common.Extensions
{
    public static class ClaimPrincipalExtensions
    {
        /// <summary>
        /// ИД пользователя
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static int UserId(this ClaimsPrincipal principal)
        {
            return int.Parse(principal.FindFirst(p => p.Type == UserClaimTypes.UserIdentifier)?.Value!);
        }
        public static string IdentityUserId(this ClaimsPrincipal principal)
        {
            return principal.FindFirst(p => p.Type == ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
