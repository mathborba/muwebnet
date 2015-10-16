using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MUwebNET.Web.Framework
{
    public static class Crypto
    {
        static int Rfc2898KeygenIterations = 100;
        static int AesKeySizeInBits = 128;
        static String Password = "muN3t 3nCr!pt4t!0n";
        static byte[] Salt = { 1, 2, 4, 8, 16, 32, 64, 2, 128, 8, 16, 32, 1, 2, 16, 32 };

        public static string Encrypt(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }
            byte[] rawPlaintext = System.Text.Encoding.Unicode.GetBytes(text);
            byte[] cipherText = null;
            using (Aes aes = new AesManaged())
            {
                aes.Padding = PaddingMode.PKCS7;
                aes.KeySize = AesKeySizeInBits;
                int KeyStrengthInBytes = aes.KeySize / 8;
                System.Security.Cryptography.Rfc2898DeriveBytes rfc2898 =
                    new System.Security.Cryptography.Rfc2898DeriveBytes(Password, Salt, Rfc2898KeygenIterations);
                aes.Key = rfc2898.GetBytes(KeyStrengthInBytes);
                aes.IV = rfc2898.GetBytes(KeyStrengthInBytes);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(rawPlaintext, 0, rawPlaintext.Length);
                    }
                    cipherText = ms.ToArray();
                }
                return ByteArrayToString(cipherText);
            }
        }

        public static string Decrypt(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] cipherText = StringToByteArray(text);
                byte[] plainText;
                using (Aes aes = new AesManaged())
                {
                    aes.Padding = PaddingMode.PKCS7;
                    aes.KeySize = AesKeySizeInBits;
                    int KeyStrengthInBytes = aes.KeySize / 8;
                    System.Security.Cryptography.Rfc2898DeriveBytes rfc2898 =
                        new System.Security.Cryptography.Rfc2898DeriveBytes(Password, Salt, Rfc2898KeygenIterations);
                    aes.Key = rfc2898.GetBytes(KeyStrengthInBytes);
                    aes.IV = rfc2898.GetBytes(KeyStrengthInBytes);
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherText, 0, cipherText.Length);
                    }
                    plainText = ms.ToArray();
                    return System.Text.Encoding.Unicode.GetString(plainText);
                }
            }
        }

        private static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        private static string ByteArrayToString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }
    }
}
