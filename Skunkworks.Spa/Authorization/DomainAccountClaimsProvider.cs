using Skunkworks.Shared;

using System.Net.Http.Json;
using System.Security.Claims;

using static System.Net.WebRequestMethods;

namespace DomainSystems.Authorization
{
    public class DomainAccountClaimsProvider(HttpClient client) : IDomainAccountClaimsProvider
    {

        public virtual async Task<ClaimsPrincipal> ExtendUserClaims(ClaimsPrincipal principal)
        {
            ClaimsIdentity claimsIdentity = (principal!.Identity as ClaimsIdentity)!;

            try
            {
                var loggedInUser = await client.GetFromJsonAsync<LoggedInUser>("User");
                foreach (var role in loggedInUser.Roles)
                {
                    if (!claimsIdentity.HasClaim(ClaimTypes.Role, role))
                    {
                        var claim = new Claim(ClaimTypes.Role, role);
                        claimsIdentity.AddClaim(claim);
                    }
                }
            }
            catch (Exception ex)
            {
                _ = ex;
            }
            return principal;
        }
    }

}
