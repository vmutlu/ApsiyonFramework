using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Apsiyon.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType) => claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal) => claimsPrincipal?.Claims(ClaimTypes.Role);
    }
}
