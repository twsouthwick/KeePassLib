namespace KeePassLib
{
#if !FEATURE_MESSAGESERVICE
    internal static class MessageService
    {
        public static string NewLine = "\n";
        public static string NewParagraph = "\r\n";
    }
#endif
}
