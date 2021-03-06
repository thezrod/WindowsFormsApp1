﻿using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
namespace WindowsFormsApp1
{
    static class SameAllTheTimeCipher
    {
        private const int Keysize = 128;
        private const int DerivationIterations = 1000;

        public static string Encrypt(string plainText, string pass)
        {
            byte[] salt = new byte[16] { 223,3,4,5,6,7,81,2,33,44,66,77,55,33,22,76};
            var iv      = new byte[16] { 110,45,234,123,22,8,43,55,46,87,9,122,112,123,254,0};
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            using (var password = new Rfc2898DeriveBytes(pass, salt, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);

                using (var symetricKey = new RijndaelManaged())
                {
                    symetricKey.BlockSize = 128;
                    symetricKey.Mode = CipherMode.CBC;
                    symetricKey.Padding = PaddingMode.PKCS7;

                    using (var encryptor = symetricKey.CreateEncryptor(keyBytes, iv))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();

                                var ciperTextBytes = salt;
                                ciperTextBytes = ciperTextBytes.Concat(iv).ToArray();
                                ciperTextBytes = ciperTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(ciperTextBytes);
                            }
                        }
                    }
                }
            }
        }
        public static string Decrypt(string cipherText, string pass)
        {
            var ciperWithSaltAndIv = Convert.FromBase64String(cipherText);
            var salt = ciperWithSaltAndIv.Take(Keysize / 8).ToArray();
            var iv = ciperWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            var cipherTextBytes = ciperWithSaltAndIv.Skip(2 * (Keysize / 8)).Take(ciperWithSaltAndIv.Length - (2 * (Keysize / 8))).ToArray();

            using (var password = new Rfc2898DeriveBytes(pass, salt, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 128;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;

                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, iv))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherText.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }
    }

}

