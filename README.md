# AbpTemplate.Cli

[![NuGet Badge](https://buildstats.info/nuget/Anto.Cli.Template)](https://www.nuget.org/packages/Anto.Cli.Template)

The CLI for you ABP app. This repo is a work in progress. I will be adding more features to this CLI. If you have any suggestions, please feel free to create an issue. If you want to contribute, please feel free to create a PR. I will be happy to review it. Thanks.

## What is this?

This is a CLI for ABP Application. you can use this to connect to you ABP application and perform some actions. For example, you can create a tenant, create a user, create a role, etc.

## Features

- [x] Login
- [x] Logout
- [x] Seed Tenant (Randomly generate tenant name, admin user, admin password, etc.)
- [x] Seed User (Randomly generate user name, password, etc.)
- [ ] Switch tenant
- [ ] Import and Export data (Maybe)

> Note: if you are wondering Import from where, I am planning to use a csv file to import and export data.

## How to use

### Install

```bash
dotnet new install Anto.Cli.Template
```

> Note: You can use any version you want. I am using 1.0.2 here.

### Create a new project

```bash
 dotnet new cli-template -o MyProject --api myabpproject.com
```

> Note: You can use any api you want. I am using myabpproject.com here.

### Run the project

```bash
cd MyProject
dotnet run
```

## How to contribute

If you want to contribute, please feel free to create a PR. I will be happy to review it. Thanks.

## License

MIT

## Author

- [Anto Subash](https://github.com/antosubash)
