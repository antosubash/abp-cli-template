using System;
using System.ComponentModel;
using Spectre.Console.Cli;
using AbpTemplate.Cli.Services;
namespace AbpTemplate.Cli.Commands.Logout;

public class LogoutCommand : AsyncCommand
{
    private readonly AuthService _authService;


    public LogoutCommand(AuthService authService)
    {
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
    }

    public override async Task<int> ExecuteAsync(CommandContext context)
    {
        _authService.Logout();
        await Task.CompletedTask;
        return 0;
    }
}