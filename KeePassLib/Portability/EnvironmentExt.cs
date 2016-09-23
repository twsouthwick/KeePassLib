
namespace KeePassLib
{
    internal static class EnvironmentExt
    {
        public static string UserName { get; } = "userName";

        public static string MachineName { get; } = "machineName";

        public static string UserDomainName { get; } = "domainName";

        public static string AppDataRoamingFolderPath { get; } = "roamingData";
    }
}
