module.exports = {
    description: "New Command",
    prompts: [
        {
            type: "input",
            name: "name",
            message: "What is your command name?",
        },
        {
            type: "input",
            name: "folder",
            message: "What is your command folder?",
        }
    ],
    actions: function (data) {
        const actions = [];
        if (data.folder) {
            actions.push({
                type: "add",
                path: "Commands/{{pascalCase folder}}/{{pascalCase name}}/{{pascalCase name}}Command.cs",
                templateFile: "plop-templates/command/command.cs.hbs",
            });
        } else {
            actions.push({
                type: "add",
                path: "Commands/{{pascalCase name}}/{{pascalCase name}}Command.cs",
                templateFile: "plop-templates/command/command.cs.hbs",
            });
        }

        actions.push({
            type: "add",
            path: "Services/{{pascalCase name}}Service.cs",
            templateFile: "plop-templates/services/service.cs.hbs",
        })
        actions.push({
            type: "append",
            path: "Program.cs",
            pattern: "// PLOP_SERVICE_REGISTRATION",
            template: "        registrations.AddScoped<{{pascalCase name}}Service>();",
        });

        actions.push({
            type: "append",
            path: "Program.cs",
            pattern: "// PLOP_COMMAND_REGISTRATION",
            template: '            config.AddCommand<{{pascalCase name}}Command>("{{name}}");',
        })

        actions.push({
            type: "append",
            path: "Program.cs",
            pattern: "// PLOP_INJECT_USING",
            template: 'using AbpTemplate.Cli.Commands.{{pascalCase name}};',
        })
        return actions;
    },
};