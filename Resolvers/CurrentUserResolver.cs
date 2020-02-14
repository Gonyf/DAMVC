using DAMVC.Extensions;
using DAMVC.Interfaces;
using DAMVC.Models;
using Microsoft.AspNetCore.Http;

namespace DAMVC.Resolvers
{
    public class CurrentUserResolver : ICurrentUserResolver
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public User Get()
        {
            var user = _httpContextAccessor.HttpContext.User.GetUser();
            return user;
        }
    }
}
