using DomainSystems.Authorization;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;

using Skunkworks.Spa;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp =>
{
    var authorizationMessageHandler = sp.GetRequiredService<AuthorizationMessageHandler>();
    var url = builder.Configuration["DownstreamApi:BaseUrl"] ?? string.Empty;
    var scopes = builder.Configuration.GetSection("DownstreamApi:Scopes").Get<string[]>() ?? [];
    authorizationMessageHandler.InnerHandler = new HttpClientHandler();
    authorizationMessageHandler = authorizationMessageHandler.ConfigureHandler(authorizedUrls: [url], scopes: scopes);
    return new HttpClient(authorizationMessageHandler)
    {
        BaseAddress = new Uri(url)
    };
});
builder.Services.AddFluentUIComponents();

builder.Services.AddScoped<IDomainAccountClaimsProvider, DomainAccountClaimsProvider>();
builder.Services.AddMsalAuthentication(options =>
{
    // Add scopes for Microsoft Graph /PWA
    var add = options.ProviderOptions.DefaultAccessTokenScopes.Add;

    add("openid");
    add("offline_access");
    var scopes = builder.Configuration.GetSection("DownstreamApi:Scopes").Get<string[]>() ?? [];
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    foreach (var scope in scopes)
        add(scope);
    options.ProviderOptions.LoginMode = "redirect";
})
.AddAccountClaimsPrincipalFactory<DomainAccountClaimsPrincipalFactory>();

await builder.Build().RunAsync();
