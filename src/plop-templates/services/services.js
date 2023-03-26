module.exports = {
    description: "New Service",
    prompts: [
        {
            type: "input",
            name: "name",
            message: "What is your service name?",
        },
    ],
    actions: function (data) {
        const actions = [];
        actions.push({
            type: "add",
            path: "AbpTemplate.Cli/Services/{{pascalCase name}}Service.cs",
            templateFile: "plop-templates/services/service.cs.hbs",
        })
        actions.push({
            type: "append",
            path: "AbpTemplate.Cli/Program.cs",
            pattern: "// PLOP_SERVICE_REGISTRATION",
            template: "        registrations.AddScoped<{{pascalCase name}}Service>();",
        });
        return actions;
    },
};