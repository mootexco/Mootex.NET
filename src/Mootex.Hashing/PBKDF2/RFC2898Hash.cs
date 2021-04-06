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
using System.Security.Cryptography;
using System.Text;

namespace Mootex.Hashing.PBKDF2 {

    public sealed class RFC2898Hash {

        public static byte[] CalculateBytes(byte[] src, byte[] salt, int iterations, int resultBytes) {

            if (salt.Length < 8) {
                throw new ArgumentOutOfRangeException(nameof(salt), "Required at least 8 bytes for salt.");
            }

            using Rfc2898DeriveBytes hasher = new Rfc2898DeriveBytes(
                src,
                salt,
                iterations,
                HashAlgorithmName.SHA512);

            return hasher.GetBytes(resultBytes);

        }

        public static byte[] CalculateBytes(byte[] src, string salt, int iterations, int resultBytes) {
            return CalculateBytes(src, Encoding.UTF8.GetBytes(salt), iterations, resultBytes);
        }

        public static byte[] CalculateBytes(string src, byte[] salt, int iterations, int resultBytes) {
            return CalculateBytes(Encoding.UTF8.GetBytes(src), salt, iterations, resultBytes);
        }

        public static byte[] CalculateBytes(string src, string salt, int iterations, int resultBytes) {
            return CalculateBytes(Encoding.UTF8.GetBytes(src), Encoding.UTF8.GetBytes(salt), iterations, resultBytes);
        }

        public static string CalculateString(byte[] src, byte[] salt, int iterations, int resultBytes) {
            return GenericHash.ByteArrayToHexString(CalculateBytes(src, salt, iterations, resultBytes));
        }

        public static string CalculateString(byte[] src, string salt, int iterations, int resultBytes) {
            return GenericHash.ByteArrayToHexString(CalculateBytes(src, salt, iterations, resultBytes));
        }

        public static string CalculateString(string src, byte[] salt, int iterations, int resultBytes) {
            return GenericHash.ByteArrayToHexString(CalculateBytes(src, salt, iterations, resultBytes));
        }

        public static string CalculateString(string src, string salt, int iterations, int resultBytes) {
            return GenericHash.ByteArrayToHexString(CalculateBytes(src, salt, iterations, resultBytes));
        }

    }

}
