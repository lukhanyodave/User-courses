using System.Security.Claims;

namespace DomainSystems.Authorization
{
    public interface IDomainAccountClaimsProvider
    {
        Task<ClaimsPrincipal> ExtendUserClaims(ClaimsPrincipal principal);
    }
}
