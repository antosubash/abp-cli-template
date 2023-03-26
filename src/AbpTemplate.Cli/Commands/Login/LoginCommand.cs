using AbpTemplate.Cli.Services;
using Spectre.Console.Cli;

namespace AbpTemplate.Cli.Commands.Login;

public class LoginCommand : AsyncCommand
{
    private readonly AuthService _authService;

    public LoginCommand(AuthService authService)
    {
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
    }

    public override async Task<int> ExecuteAsync(CommandContext context)
    {
        await _authService.LoginAsync();
        return 0;
    }
}