using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;

using System.Security.Claims;

namespace DomainSystems.Authorization
{

    internal class DomainAccountClaimsPrincipalFactory
        : AccountClaimsPrincipalFactory<RemoteUserAccount>
    {
        // Can't work with actual services in the constructor here, have to
        // use IServiceProvider, otherwise the app hangs at startup.
        // The culprit is probably HttpClient, as this class is instantiated
        // at startup while the HttpClient is being (or not even) created.
        private readonly IServiceProvider _services;

        public DomainAccountClaimsPrincipalFactory(
            IAccessTokenProviderAccessor accessor,
            IServiceProvider services)
            : base(accessor)
        {
            _services = services;
        }

        public override async ValueTask<ClaimsPrincipal> CreateUserAsync(RemoteUserAccount account, RemoteAuthenticationUserOptions options)
        {
            var principal = await base.CreateUserAsync(account, options);
            var userIdentity = (ClaimsIdentity?)principal.Identity;
            if (account != null && userIdentity?.IsAuthenticated is true)
            {
                // Resolve the claims provider from the service provider to avoid circular dependency
                var userClaimsProvider = _services.GetService<IDomainAccountClaimsProvider>();
                if (userClaimsProvider != null)
                {
                    principal = await userClaimsProvider.ExtendUserClaims(principal);
                }
            }
            return principal;
        }
    }

}
