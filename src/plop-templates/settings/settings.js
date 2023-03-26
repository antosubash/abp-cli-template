module.exports = {
    description: "New Settings",
    prompts: [
        {
            type: "input",
            name: "name",
            message: "What is your settings name?",
        },
        {
            type: "input",
            name: "folder",
            message: "What is your settings folder?",
        }
    ],
    actions: function (data) {
        const actions = [];
        if(data.folder) {
            actions.push({
                type: "add",
                path: "AbpTemplate.Cli/Commands/{{pascalCase folder}}/{{pascalCase name}}Settings.cs",
                templateFile: "plop-templates/settings/settings.cs.hbs",
            });
        }
       
        return actions;
    },
};