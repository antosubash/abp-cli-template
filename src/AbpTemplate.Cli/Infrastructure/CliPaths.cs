namespace AbpTemplate.Cli.Infrastructure
{
    public static class CliPaths
    {
        public static string Log => Path.Combine(RootPath, "cli", "logs");
        public static string Root => Path.Combine(RootPath, "cli");

        public static string AccessToken => Path.Combine(RootPath, "cli", "access-token.bin");
        public static string RefreshToken => Path.Combine(RootPath, "cli", "refresh-token.bin");

        public static string Tenant => Path.Combine(RootPath, "cli", "tenant.bin");
        public static readonly string RootPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".AbpTemplate");
    }
}
