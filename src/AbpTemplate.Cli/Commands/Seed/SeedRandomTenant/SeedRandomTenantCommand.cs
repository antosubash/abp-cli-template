using System;
using System.ComponentModel;
using Spectre.Console.Cli;
using AbpTemplate.Cli.Services;

namespace AbpTemplate.Cli.Commands.SeedRandomTenant;

public class SeedRandomTenantCommand : AsyncCommand<SeedRandomTenantCommand.Settings>
{
    private readonly RandomDataSeedingService _seedRandomTenantService;

    public sealed class Settings : CommandSettings
    {
    }

    public SeedRandomTenantCommand(RandomDataSeedingService seedRandomTenantService)
    {
        _seedRandomTenantService = seedRandomTenantService ?? throw new ArgumentNullException(nameof(seedRandomTenantService));
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        await _seedRandomTenantService.GenerateRandomTenant();
        return 0;
    }
}