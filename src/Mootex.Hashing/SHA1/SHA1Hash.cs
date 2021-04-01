// Mootex.NET - A set of libraries and helpers for .NET software
// Copyright (C) 2020 Jose J. Fernández (https://limitrek.com)
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with this program. If not, see <https://www.gnu.org/licenses/>.
using System.IO;
using System.Security.Cryptography;

namespace Mootex.Hashing.SHA1 {

    public sealed class SHA1Hash {

        public static byte[] CalculateBytes(Stream src) {
            return GenericHash.CalculateBytes(src, () => new SHA1Managed());
        }

        public static byte[] CalculateBytes(byte[] src) {
            return GenericHash.CalculateBytes(src, () => new SHA1Managed());
        }

        public static byte[] CalculateBytes(string src) {
            return GenericHash.CalculateBytes(src, () => new SHA1Managed());
        }

        public static string CalculateString(Stream src) {
            return GenericHash.CalculateString(src, () => new SHA1Managed());
        }

        public static string CalculateString(byte[] src) {
            return GenericHash.CalculateString(src, () => new SHA1Managed());
        }

        public static string CalculateString(string src) {
            return GenericHash.CalculateString(src, () => new SHA1Managed());
        }

    }

}
