using FreelanceTK.Application.Common.Extensions;
using FreelanceTK.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace FreelanceTK.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IReadOnlyDbContext dbContext;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor, IReadOnlyDbContext dbContext)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }

        public string UserId => GetUserId();

        public int ApplicationUserId => GetApplicationUserId();


        private string GetUserId()
        {
            return httpContextAccessor.HttpContext?.User?.IdentityUserId();
        }


        private int GetApplicationUserId()
        {
            return httpContextAccessor.HttpContext?.User?.UserId() ?? 0;
        }
    }
}
