namespace MrMoney.Util.Global
{
    public static class DbConnectionConfiguration
    {
        public static string? ConnectionString { get; set; }
        public static string? DatabaseName { get; set; }
        public static bool IsSSL { get; set; }

    }
}
