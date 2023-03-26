module.exports = function generator(plop) {
    plop.setDefaultInclude({ generators: true });
    plop.setGenerator("command", require("./plop-templates/command/command.js"));
    plop.setGenerator("settings", require("./plop-templates/settings/settings.js"));
    plop.setGenerator("service", require("./plop-templates/services/services.js"));
};