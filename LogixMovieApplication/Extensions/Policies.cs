using Logix_Movie_Application.Models;
using Microsoft.AspNetCore.Authorization;

namespace Logix_Movie_Application.Extensions
{
    public static class Policies
    {
        public static AuthorizationPolicy UserPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                    .RequireRole(UserRoles.User)
                    .Build();
        }
    }
}
