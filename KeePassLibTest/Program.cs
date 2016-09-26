using KeePassLib;
using KeePassLib.Keys;
using KeePassLib.Serialization;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace KeePassLibTest
{
    public class Test
    {
        private readonly ITestOutputHelper _output;

        public Test(ITestOutputHelper output)
        {
            _output = output;
        }

        private static string GetFullPath(string path)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "Assets", path);
        }

        [InlineData("password-aes_rijndael_256.kdbx", "12345", false, 2)]
        [InlineData("password-key-aes_rijndael_256.kdbx", "12345", true, 2)]
        [InlineData("key-aes_rijndael_256.kdbx", null, true, 2)]
        [Theory]
        public void Decryption(string path, string password, bool hasKey, int count)
        {
            var key = new CompositeKey();

            if (password != null)
            {
                key.AddUserKey(new KcpPassword("12345"));
            }

            if (hasKey)
            {
                var keyPath = $"{Path.GetFileNameWithoutExtension(path)}.key";
                key.AddUserKey(new KcpKeyFile(File.ReadAllBytes(GetFullPath(keyPath))));
            }

            var db = new PwDatabase
            {
                MasterKey = key
            };

            var file = new KdbxFile(db);
            file.Load(GetFullPath(path), KdbxFormat.Default, null);

            Assert.Equal(count, (int)db.RootGroup.Entries.UCount);
        }
    }
}
