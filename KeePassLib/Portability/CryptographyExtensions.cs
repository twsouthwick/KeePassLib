namespace System.Security.Cryptography
{
    internal static class Crypto
    {
        public static class SHA256
        {
            public static byte[] ComputeHash(byte[] buffer)
            {
#if !KeePassUAP
                using(SHA256Managed sha256 = new SHA256Managed())
#else
                using (var sha256 = System.Security.Cryptography.SHA256.Create())
#endif
                {
                    return sha256.ComputeHash(buffer);
                }
            }

            public static byte[] ComputeHash(byte[] buffer, int offset, int count)
            {
#if !KeePassUAP
                using(SHA256Managed sha256 = new SHA256Managed())
#else
                using (var sha256 = System.Security.Cryptography.SHA256.Create())
#endif
                {
                    return sha256.ComputeHash(buffer, offset, count);
                }
            }
        }

        public static class SHA512
        {
            public static byte[] ComputeHash(byte[] buffer)
            {
#if KeePassLibSD
                using(SHA256Managed sha = new SHA256Managed())
#elif KeePassUAP
                using (var sha = System.Security.Cryptography.SHA512.Create())
#else
                using (SHA512Managed sha = new SHA512Managed())
#endif
                {
                    return sha.ComputeHash(buffer);
                }
            }
        }
    }

#if KeePassUAP
    internal enum MemoryProtectionScope
    {
        SameProcess
    }

    internal static class ProtectedMemory
    {
        public static void Protect(byte[] data, MemoryProtectionScope scope)
        {
            ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);
        }

        public static void Unprotect(byte[] data, MemoryProtectionScope scope)
        {
            ProtectedData.Unprotect(data, null, DataProtectionScope.CurrentUser);
        }
    }
#endif
}
