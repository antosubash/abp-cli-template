using AbpTemplate.Cli.Proxy;
using Bogus;
using Spectre.Console;
namespace AbpTemplate.Cli.Services;

public class RandomDataSeedingService
{
    private readonly AbpTemplateClient abpTemplateClient;

    public RandomDataSeedingService(AbpTemplateClient abpTemplateClient)
    {
        this.abpTemplateClient = abpTemplateClient;
    }
    public async Task GenerateRandomTenant()
    {
        AnsiConsole.MarkupLine($"Starting! [green] [/]");
        var fakeTenantCreateDto = new Faker<TenantCreateDto>()
            .RuleFor(x => x.Name, f => f.Company.CompanyName())
            .RuleFor(x => x.AdminEmailAddress, f => f.Internet.Email())
            .RuleFor(x => x.AdminPassword, f => "1q2w3E*");

        for (int i = 0; i < 100; i++)
        {
            var tenantCreateDto = fakeTenantCreateDto.Generate();
            tenantCreateDto.ExtraProperties = new Dictionary<string, object>();
            AnsiConsole.MarkupLine($"Generated tenant! [green][/]");
            AnsiConsole.MarkupLine($"Name: [green]{tenantCreateDto.Name}[/]");
            AnsiConsole.MarkupLine($"AdminEmailAddress: [green]{tenantCreateDto.AdminEmailAddress}[/]");
            AnsiConsole.MarkupLine($"AdminPassword: [green]{tenantCreateDto.AdminPassword}[/]");
            AnsiConsole.MarkupLine($"Creating tenant! [green][/]");
            var res = await abpTemplateClient.TenantCreateAsync(tenantCreateDto);
            if (res != null)
                AnsiConsole.MarkupLine($"Tenant created! [green][/]");
            else
                AnsiConsole.MarkupLine($"Tenant creation failed! [red]");
        }
    }

    public async Task GenerateRandomUser()
    {
        AnsiConsole.MarkupLine($"Starting! [green] [/]");
        var fakeUserCreateDto = new Faker<IdentityUserCreateDto>()
            .RuleFor(x => x.UserName, f => f.Internet.UserName())
            .RuleFor(x => x.Email, f => f.Internet.Email())
            .RuleFor(x => x.Password, f => "1q2w3E*")
            .RuleFor(x => x.Name, f => f.Name.FullName())
            .RuleFor(x => x.Surname, f => f.Name.LastName())
            .RuleFor(x => x.PhoneNumber, f => f.Phone.PhoneNumber("+##########"));

        for (int i = 0; i < 100; i++)
        {
            var userCreateDto = fakeUserCreateDto.Generate();
            userCreateDto.ExtraProperties = new Dictionary<string, object>();
            AnsiConsole.MarkupLine($"Generated user! [green][/]");
            AnsiConsole.MarkupLine($"UserName: [green]{userCreateDto.UserName}[/]");
            AnsiConsole.MarkupLine($"EmailAddress: [green]{userCreateDto.Email}[/]");
            AnsiConsole.MarkupLine($"Password: [green]{userCreateDto.Password}[/]");
            AnsiConsole.MarkupLine($"Name: [green]{userCreateDto.Name}[/]");
            AnsiConsole.MarkupLine($"Surname: [green]{userCreateDto.Surname}[/]");
            AnsiConsole.MarkupLine($"PhoneNumber: [green]{userCreateDto.PhoneNumber}[/]");
            AnsiConsole.MarkupLine($"Creating user! [green][/]");
            var res = await abpTemplateClient.UserCreateAsync(userCreateDto);
            if (res != null)
                AnsiConsole.MarkupLine($"User created! [green][/]");
            else
                AnsiConsole.MarkupLine($"User creation failed! [red]");
        }
    }
}