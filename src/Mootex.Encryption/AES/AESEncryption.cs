using System;
using System.IO;
using System.Security.Cryptography;

namespace Mootex.Encryption.AES {

    public sealed class AESEncryption {

        public static byte[] Encrypt(string data, byte[] key, byte[] iv) {

            if (data == null) {
                throw new ArgumentNullException(nameof(data));
            }

            if (data.Length <= 0) {
                throw new ArgumentException("Invalid data length.", nameof(data));
            }

            if (key == null) {
                throw new ArgumentNullException(nameof(key));
            }

            if (!CheckKey(key)) {
                throw new ArgumentException("Invalid key length.", nameof(key));
            }

            if (iv == null) {
                throw new ArgumentNullException(nameof(iv));
            }

            if (iv.Length != 16) {
                throw new ArgumentException("Invalid iv length.", nameof(iv));
            }

            byte[] encrypted;

            using (Aes aes = Create(key, iv)) {

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream msEncrypt = new MemoryStream()) {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)) {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt)) {
                            swEncrypt.Write(data);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }

            }

            return encrypted;

        }

        public static string Decrypt(byte[] data, byte[] key, byte[] iv) {

            if (data == null) {
                throw new ArgumentNullException(nameof(data));
            }

            if (data.Length <= 0) {
                throw new ArgumentException("Invalid data length.", nameof(data));
            }

            if (key == null) {
                throw new ArgumentNullException(nameof(key));
            }

            if (!CheckKey(key)) {
                throw new ArgumentException("Invalid key length.", nameof(key));
            }

            if (iv == null) {
                throw new ArgumentNullException(nameof(iv));
            }

            if (iv.Length != 16) {
                throw new ArgumentException("Invalid iv length.", nameof(iv));
            }

            string plaintext = string.Empty;

            using (Aes aes = Create(key, iv)) {

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream msDecrypt = new MemoryStream(data)) {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)) {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt)) {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }

        private static Aes Create(byte[] key, byte[] iv) {

            Aes aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Key = key;
            aes.IV = iv;

            return aes;

        }

        private static bool CheckKey(byte[] key) {
            return Aes.Create().ValidKeySize(key.Length * 8);
        }

    }

}
