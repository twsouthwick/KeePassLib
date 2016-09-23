using System.Xml;
using System;
using System.Security.Cryptography;

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
