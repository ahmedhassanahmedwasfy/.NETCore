using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Target_NETCORE.Helpers
{
    public class RS256_Helper
    {
        private static string publicKey;
        private static string privateKey;
        public enum KeySizes
        {
            SIZE_512 = 512,
            SIZE_1024 = 1024,
            SIZE_2048 = 2048,
            SIZE_952 = 952,
            SIZE_1369 = 1369
        };
        public static string Decrypt(string encrypted)
        {
            string decrypted;
            using (var rsa = new RSACryptoServiceProvider((int)KeySizes.SIZE_2048))
            {
                rsa.PersistKeyInCsp = false;

                rsa.FromXmlString(privateKey);
                var bts = Convert.FromBase64String(encrypted);
                var b_decrypted = rsa.Decrypt(bts, true);
                decrypted = System.Text.UTF8Encoding.UTF8.GetString(b_decrypted);
            }
            return decrypted;
        }
        public static string Encrypt(string plain)
        {
            string encrypted;
            using (var rsa = new RSACryptoServiceProvider((int)KeySizes.SIZE_2048))
            {
                rsa.PersistKeyInCsp = false;

                rsa.FromXmlString(publicKey);
                var b_inp = System.Text.UTF8Encoding.UTF8.GetBytes(plain);
                var b_encrypted = rsa.Encrypt(b_inp, true);
                encrypted = Convert.ToBase64String(b_encrypted);
            }
            return encrypted;
        }
        public static void generateKeys(string publicKeyFile, string privateKeyFile)
        {
            using (var rsa = new RSACryptoServiceProvider((int)KeySizes.SIZE_2048))
            {
                rsa.PersistKeyInCsp = false;

                if (File.Exists(privateKeyFile))
                    File.Delete(privateKeyFile);

                if (File.Exists(publicKeyFile))
                    File.Delete(publicKeyFile);


                publicKey = rsa.ToXmlString(false);
                File.WriteAllText(publicKeyFile, publicKey);
                privateKey = rsa.ToXmlString(true);
                File.WriteAllText(privateKeyFile, privateKey);
            }
        }
        public static void loadKeys(string publicKeyFile, string privateKeyFile)
        {
            using (var rsa = new RSACryptoServiceProvider((int)KeySizes.SIZE_2048))
            {
                rsa.PersistKeyInCsp = false;

                if (File.Exists(privateKeyFile))
                    privateKey = File.ReadAllText(privateKeyFile);

                if (File.Exists(publicKeyFile))
                    publicKey = File.ReadAllText(publicKeyFile);
            }
        }
    }
}