using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;

namespace DAMVC.Extensions
{
    public static class ControllerExtensions
    {
        public static string GetLoggedInUserName(this Controller c)
        {
            var userName = c.HttpContext.User.Identity.Name;
            return userName;
        }
        public static bool HavePermission(this IIdentity claims, string claimValue)
        {
            var userClaims = claims as ClaimsIdentity;
            bool havePer = userClaims.HasClaim(claimValue, claimValue);
            return havePer;
        }
    }
}
