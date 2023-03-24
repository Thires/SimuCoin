using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SimuCoin
{
    public class EncryptDecrypt
    {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("4233445456940954");
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("3333333935435904");

        public static string Encrypt(string plainText)
        {
            using var aesAlg = Aes.Create();
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using var msEncrypt = new MemoryStream();
            using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            using var swEncrypt = new StreamWriter(csEncrypt);
            swEncrypt.Write(plainText);

            var encryptedBytes = msEncrypt.ToArray();
            return Convert.ToBase64String(encryptedBytes);
        }

        public static string Decrypt(string cipherText)
        {
            var cipherBytes = Convert.FromBase64String(cipherText);

            using var aesAlg = Aes.Create();
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using var msDecrypt = new MemoryStream(cipherBytes);
            using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            using var srDecrypt = new StreamReader(csDecrypt);
            return srDecrypt.ReadToEnd();
        }
    }
}
