using Spectre.Console;
namespace AbpTemplate.Cli.Services;

public class SwitchService
{
    private readonly AuthService _authService;
    public SwitchService(AuthService authService)
    {
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
    }

    public async Task ChangeTenant(string name)
    {
        AnsiConsole.MarkupLine($"[green]Switching to tenant: {name}[/]!");
        await _authService.SwitchTenantAsync(name);
    }
}