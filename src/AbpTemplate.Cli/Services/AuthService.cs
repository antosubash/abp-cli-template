using AbpTemplate.Cli.Infrastructure;
using IdentityModel.OidcClient;
using Spectre.Console;

namespace AbpTemplate.Cli.Services;

public class AuthService
{
    static OidcClient? _oidcClient;
    public AuthService()
    {

    }

    public async Task<string> GetAccessTokenAsync()
    {
        var accessToken = await File.ReadAllTextAsync(CliPaths.AccessToken);
        return accessToken;
    }

    public async Task<string> GetTenantAsync()
    {
        try
        {
            var tenant = await File.ReadAllTextAsync(CliPaths.Tenant);
            return tenant;
        }
        catch (Exception e)
        {
            AnsiConsole.WriteException(e);
            return string.Empty;
        }
    }

    public async Task<string> SwitchTenantAsync(string tenant)
    {
        await File.WriteAllTextAsync(CliPaths.Tenant, tenant);
        return tenant;
    }

    public async Task<bool> IsAuthenticatedAsync()
    {
        if (!File.Exists(CliPaths.AccessToken))
            return false;

        var accessToken = await GetAccessTokenAsync();
        return !string.IsNullOrEmpty(accessToken);
    }

    public async Task LoginAsync()
    {
        // create a redirect URI using an available port on the loopback address.
        // requires the OP to allow random ports on 127.0.0.1 - otherwise set a static port
        var browser = new SystemBrowser(3000);
        string redirectUri = string.Format($"http://localhost:{browser.Port}");

        var options = new OidcClientOptions
        {
            Authority = Constants.IdentityUrl,
            ClientId = "AbpTemplate_Cli",
            RedirectUri = redirectUri,
            Scope = "openid profile roles AbpTemplate",
            FilterClaims = false,
            Browser = browser,
        };

        _oidcClient = new OidcClient(options);
        var result = await _oidcClient.LoginAsync(new LoginRequest());
        if(result.IsError)
        {
            Console.WriteLine(result.Error);
            return;
        }
        if(!Directory.Exists(CliPaths.Root))
        {
            Directory.CreateDirectory(CliPaths.Root);
        }

        if(!Directory.Exists(CliPaths.Root))
        {
            Directory.CreateDirectory(CliPaths.Root);
        }
        Console.WriteLine("Login successful");
        await File.WriteAllTextAsync(CliPaths.AccessToken, result.AccessToken);
        await File.WriteAllTextAsync(CliPaths.RefreshToken, result.RefreshToken);
    }

    public void Logout()
    {
        if (File.Exists(CliPaths.AccessToken))
            File.Delete(CliPaths.AccessToken);

        if (File.Exists(CliPaths.RefreshToken))
            File.Delete(CliPaths.RefreshToken);

        if (File.Exists(CliPaths.Tenant))
            File.Delete(CliPaths.Tenant);
    }
}