#if NETSTANDARD1_3

using System;

namespace KeePassLib
{
    internal static class PortableExtensions
    {
        public static void Close(this IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}
#endif
