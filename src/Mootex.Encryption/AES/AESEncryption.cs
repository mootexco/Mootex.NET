// Mootex.NET - A set of libraries and helpers for .NET software
// Copyright (C) 2020 Jose J. Fernández (https://mootex.co)
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License version 3
// as published by the Free Software Foundation.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with this program. If not, see <https://www.gnu.org/licenses/>.
using System;
using System.IO;
using System.Security.Cryptography;

namespace Mootex.Encryption.AES {

    public sealed class AESEncryption {

        private readonly string key;

        public AESEncryption(string encryptionKey) {

            if (string.IsNullOrEmpty(encryptionKey)) {
                throw new ArgumentNullException(nameof(encryptionKey));
            }

            this.key = encryptionKey;

        }

        private AesManaged CreateAes() {

            AesManaged aes = new AesManaged();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            Rfc2898DeriveBytes source = new(this.key, new byte[8]);
            aes.Key = source.GetBytes(aes.KeySize / 8);
            aes.IV = source.GetBytes(aes.BlockSize / 8);

            return aes;

        }

        public string Encrypt(string data) {

            if (string.IsNullOrEmpty(data)) {
                throw new ArgumentNullException(nameof(data));
            }

            using (AesManaged aes = this.CreateAes()) {
                using (ICryptoTransform encryptor = aes.CreateEncryptor()) {
                    using (MemoryStream msEncrypt = new()) {
                        using (CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write)) {
                            using (StreamWriter swEncrypt = new(csEncrypt)) {
                                swEncrypt.Write(data);
                            }
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }

        }

        public string Decrypt(string data) {

            if (string.IsNullOrEmpty(data)) {
                throw new ArgumentNullException(nameof(data));
            }

            using (AesManaged aes = this.CreateAes()) {
                using (ICryptoTransform decryptor = aes.CreateDecryptor()) {
                    using (MemoryStream msDecrypt = new(Convert.FromBase64String(data))) {
                        using (CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read)) {
                            using (StreamReader srDecrypt = new(csDecrypt)) {
                                return srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }

        }

    }

}
