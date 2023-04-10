using System.Security.Cryptography;
using System.Text;

namespace SimuCoins
{
    public class EncryptDecrypt
    {
        public static string Encrypt(string plainText)
        {
            byte[] plainBytes = Encoding.ASCII.GetBytes(plainText);
            using Aes aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.GenerateKey();
            aes.GenerateIV();
            using ICryptoTransform encryptor = aes.CreateEncryptor();
            byte[] cipherBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            byte[] ivAndCipherBytes = new byte[aes.IV.Length + cipherBytes.Length];
            Buffer.BlockCopy(aes.IV, 0, ivAndCipherBytes, 0, aes.IV.Length);
            Buffer.BlockCopy(cipherBytes, 0, ivAndCipherBytes, aes.IV.Length, cipherBytes.Length);
            string keyAndIv = Convert.ToBase64String(aes.Key) + ":" + Convert.ToBase64String(ivAndCipherBytes);
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(keyAndIv));
        }

        public static string Decrypt(string cipherText)
        {
            string keyAndIv = Encoding.UTF8.GetString(Convert.FromBase64String(cipherText));
            string[] parts = keyAndIv.Split(':');
            byte[] keyBytes = Convert.FromBase64String(parts[0]);
            byte[] ivAndCipherBytes = Convert.FromBase64String(parts[1]);
            using Aes aes = Aes.Create();
            aes.Key = keyBytes;
            aes.IV = ivAndCipherBytes.Take(aes.IV.Length).ToArray();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            using ICryptoTransform decryptor = aes.CreateDecryptor();
            byte[] cipherBytes = ivAndCipherBytes.Skip(aes.IV.Length).ToArray();
            byte[] plainBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
            return Encoding.ASCII.GetString(plainBytes);
        }
    }
}