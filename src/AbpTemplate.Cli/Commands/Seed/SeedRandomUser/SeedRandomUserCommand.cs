using Spectre.Console.Cli;
using AbpTemplate.Cli.Services;

namespace AbpTemplate.Cli.Commands.SeedRandomUser;

public class SeedRandomUserCommand : AsyncCommand<SeedRandomUserCommand.Settings>
{
    private readonly RandomDataSeedingService _seedRandomUserService;

    public sealed class Settings : CommandSettings
    {

    }

    public SeedRandomUserCommand(RandomDataSeedingService seedRandomUserService)
    {
        _seedRandomUserService = seedRandomUserService ?? throw new ArgumentNullException(nameof(seedRandomUserService));
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        await _seedRandomUserService.GenerateRandomUser();
        return 0;
    }
}