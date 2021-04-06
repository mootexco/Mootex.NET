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
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Mootex.Hashing {

    public sealed class GenericHash {

        public static byte[] CalculateBytes(Stream src, Func<HashAlgorithm> createHash) {

            byte[] passwordHashBytes;

            using (HashAlgorithm hash = createHash()) {
                passwordHashBytes = hash.ComputeHash(src);
            }

            return passwordHashBytes;

        }

        public static byte[] CalculateBytes(byte[] src, Func<HashAlgorithm> createHash) {

            byte[] passwordHashBytes;

            using (HashAlgorithm hash = createHash()) {
                passwordHashBytes = hash.ComputeHash(src);
            }

            return passwordHashBytes;

        }

        public static byte[] CalculateBytes(string src, Func<HashAlgorithm> createHash) {
            return CalculateBytes(Encoding.UTF8.GetBytes(src), createHash);
        }

        public static string CalculateString(Stream src, Func<HashAlgorithm> createHash) {
            return ByteArrayToHexString(CalculateBytes(src, createHash));
        }

        public static string CalculateString(byte[] src, Func<HashAlgorithm> createHash) {
            return ByteArrayToHexString(CalculateBytes(src, createHash));
        }

        public static string CalculateString(string src, Func<HashAlgorithm> createHash) {
            return CalculateString(Encoding.UTF8.GetBytes(src), createHash);
        }

        public static string ByteArrayToHexString(byte[] src) {
            return string.Concat(src.Select(x => x.ToString("X2")));
        }

    }

}
