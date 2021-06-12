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
// using System;
using System;
using Mootex.Encryption.AES;
using Xunit;

namespace Mootex.Encryption.Test {

    public sealed class AESEncryptionTests {

        [Fact]
        public void EncryptionKeyIsChecked() {
            new AESEncryption(" ");
            Assert.Throws<ArgumentNullException>(() => new AESEncryption(null));
            Assert.Throws<ArgumentNullException>(() => new AESEncryption(string.Empty));
        }

        [Fact]
        public void EncryptionDataIsChecked() {

            AESEncryption aes = new AESEncryption(" ");

            aes.Encrypt(" ");
            Assert.Throws<ArgumentNullException>(() => aes.Encrypt(null));
            Assert.Throws<ArgumentNullException>(() => aes.Encrypt(string.Empty));

            aes.Decrypt(" ");
            Assert.Throws<ArgumentNullException>(() => aes.Decrypt(null));
            Assert.Throws<ArgumentNullException>(() => aes.Decrypt(string.Empty));

        }

        [Fact]
        public void EncryptAndDecryptOk() {

            string original = "Hello, world!";
            string password = "key";

            AESEncryption aes = new AESEncryption(password);
            string encrypted = aes.Encrypt(original);
            string decrypted = aes.Decrypt(encrypted);

            Assert.Equal(original, decrypted);

        }

    }

}
