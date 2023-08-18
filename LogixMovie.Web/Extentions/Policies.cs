using LogixMovie.Application.Constants;
using Microsoft.AspNetCore.Authorization;

namespace LogixMovie.Web.Extentions
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
