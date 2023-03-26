using System.ComponentModel;
using Spectre.Console.Cli;
using AbpTemplate.Cli.Services;
using Spectre.Console;

namespace AbpTemplate.Cli.Commands.SwitchTenant;

public class SwitchTenantCommand : AsyncCommand<SwitchTenantCommand.Settings>
{
    private readonly SwitchService _switchService;

    public sealed class Settings : CommandSettings
    {
        [CommandArgument(0, "[NAME]")]
        [Description("The name of the tenant.")]
        public string? Name { get; init; }
    }

    public SwitchTenantCommand(SwitchService switchTenantService)
    {
        _switchService = switchTenantService ?? throw new ArgumentNullException(nameof(switchTenantService));
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        if(string.IsNullOrWhiteSpace(settings.Name))
        {
            AnsiConsole.MarkupLine($"[red]Tenant name is required.[/]");
            return 1;
        }
        await _switchService.ChangeTenant(settings.Name);
        AnsiConsole.MarkupLine($"[green]Successfully switched to {settings.Name}[/]");
        return 0;
    }
}