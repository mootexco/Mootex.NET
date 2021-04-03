using System;
using System.IO;
using System.Security.Cryptography;

namespace Mootex.Encryption.AES {

    public sealed class AESEncryption {

        /*
         * CipherMode = CBC
         * KeySize = 256 bits, 32 bytes
         * IV length = 128 bits, 16 bytes
         */

        public byte[] Encrypt(string data, byte[] key, byte[] iv) {

            if (data == null || data.Length <= 0) {
                throw new ArgumentNullException(nameof(data));
            }

            if (key == null || key.Length < 32) {
                throw new ArgumentNullException(nameof(key));
            }

            if (iv == null || iv.Length < 16) {
                throw new ArgumentNullException(nameof(iv));
            }

            byte[] encrypted;

            using (AesManaged aesAlg = new AesManaged() { Key = key, IV = iv }) {

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

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

        public string Decrypt(byte[] data, byte[] key, byte[] iv) {

            if (data == null || data.Length <= 0) {
                throw new ArgumentNullException(nameof(data));
            }

            if (key == null || key.Length <= 0) {
                throw new ArgumentNullException(nameof(key));
            }

            if (iv == null || iv.Length <= 0) {
                throw new ArgumentNullException(nameof(iv));
            }

            string plaintext = string.Empty;

            using (AesManaged aesAlg = new AesManaged() { Key = key, IV = iv }) {

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

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

    }

}
