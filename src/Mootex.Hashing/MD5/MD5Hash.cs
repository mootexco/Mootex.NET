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
using System.IO;

namespace Mootex.Hashing.MD5 {

    public sealed class MD5Hash {

        public static byte[] CalculateBytes(Stream src) {
            return GenericHash.CalculateBytes(src, () => System.Security.Cryptography.MD5.Create());
        }

        public static byte[] CalculateBytes(byte[] src) {
            return GenericHash.CalculateBytes(src, () => System.Security.Cryptography.MD5.Create());
        }

        public static byte[] CalculateBytes(string src) {
            return GenericHash.CalculateBytes(src, () => System.Security.Cryptography.MD5.Create());
        }

        public static string CalculateString(Stream src) {
            return GenericHash.CalculateString(src, () => System.Security.Cryptography.MD5.Create());
        }

        public static string CalculateString(byte[] src) {
            return GenericHash.CalculateString(src, () => System.Security.Cryptography.MD5.Create());
        }

        public static string CalculateString(string src) {
            return GenericHash.CalculateString(src, () => System.Security.Cryptography.MD5.Create());
        }

    }

}
