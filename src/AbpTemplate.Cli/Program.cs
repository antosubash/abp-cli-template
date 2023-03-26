
using AbpTemplate.Cli.Commands.Login;
using AbpTemplate.Cli.Commands.Logout;
using AbpTemplate.Cli.Commands.SeedRandomTenant;
using AbpTemplate.Cli.Commands.SeedRandomUser;
using AbpTemplate.Cli.Commands.SwitchTenant;
using AbpTemplate.Cli.Handlers;
using AbpTemplate.Cli.Infrastructure;
using AbpTemplate.Cli.Proxy;
using AbpTemplate.Cli.Services;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;
// PLOP_INJECT_USING

var registrations = new ServiceCollection();
registrations.AddScoped<AuthService>();
registrations.AddScoped<HeaderHandler>();
registrations.AddScoped<SwitchService>();
// PLOP_SERVICE_REGISTRATION
registrations.AddScoped<RandomDataSeedingService>();

registrations.AddHttpClient<AbpTemplateClient>(client =>
{
    client.BaseAddress = new Uri(Constants.ApiUrl);
})
.AddHttpMessageHandler<HeaderHandler>();
var registrar = new TypeRegistrar(registrations);
var app = new CommandApp(registrar);
app.Configure(config =>
{
    config.AddCommand<LoginCommand>("login")
        .WithDescription("Login to AbpTemplate")
        .WithExample(new[] { "login" });
    config.AddCommand<LogoutCommand>("logout")
        .WithDescription("Logout from AbpTemplate")
        .WithExample(new[] { "logout" });

    config.AddBranch("tenant", tenant =>
    {
        tenant.AddCommand<SwitchTenantCommand>("switch")
            .WithDescription("Switch tenant")
            .WithExample(new[] { "tenant switch" });
    });

    config.AddBranch("seed", seed =>
    {
        seed.AddCommand<SeedRandomTenantCommand>("tenant")
            .WithDescription("Seed random tenant")
            .WithExample(new[] { "seed tenant" });
        seed.AddCommand<SeedRandomUserCommand>("user")
            .WithDescription("Seed random user")
            .WithExample(new[] { "seed user" });
    });

    // PLOP_COMMAND_REGISTRATION
});
return app.Run(args);