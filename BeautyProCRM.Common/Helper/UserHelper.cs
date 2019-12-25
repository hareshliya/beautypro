using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BeautyProCRM.Common.Helper
{
    public class UserHelper
    {
        private const string mkey = "4EB9ABFD98BA2E25F5F1B0403AE67F37188069EDD2B41460BCD9182B619CC4D9";

        public static string Encrypt(string dataToEncrypt)
        {
            byte[] key = GetHashKey(mkey);
            // Initialize
            AesManaged encryptor = new AesManaged();
            // Set the key
            encryptor.Key = key;
            encryptor.IV = key;
            // create a memory stream
            using (MemoryStream encryptionStream = new MemoryStream())
            {
                // Create the crypto stream
                using (CryptoStream encrypt = new CryptoStream(encryptionStream, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    // Encrypt
                    byte[] utfD1 = UTF8Encoding.UTF8.GetBytes(dataToEncrypt);
                    encrypt.Write(utfD1, 0, utfD1.Length);
                    encrypt.FlushFinalBlock();
                    encrypt.Close();
                    // Return the encrypted data
                    return Convert.ToBase64String(encryptionStream.ToArray());
                }
            }
        }

        public static byte[] GetHashKey(string hashKey)
        {
            // Initialize
            UTF8Encoding encoder = new UTF8Encoding();
            // Get the salt
            string salt = "2790164838";
            byte[] saltBytes = encoder.GetBytes(salt);
            // Setup the hasher
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(hashKey, saltBytes);
            // Return the key
            return rfc.GetBytes(16);
        }
    }
}
