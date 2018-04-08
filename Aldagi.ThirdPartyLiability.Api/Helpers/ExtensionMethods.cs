using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aldagi.ThirdPartyLiability.Api.Helpers
{
    public static class ExtensionMethods
    {
        public static int GetInternalUserId(this ClaimsPrincipal principal)
        {
            return int.Parse(principal.Claims.Where(x => x.Type == "client_identityUserId").FirstOrDefault().Value);
        }
    }
}
