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
using System.Text;

namespace Mootex.Hashing.MD5 {

    public sealed class HMACMD5Hash {

        public static byte[] CalculateBytes(Stream src, byte[] key) {
            return GenericHash.CalculateBytes(src, () => new HMACMD5(key));
        }

        public static byte[] CalculateBytes(Stream src, string key) {
            return GenericHash.CalculateBytes(src, () => new HMACMD5(Encoding.UTF8.GetBytes(key)));
        }

        public static byte[] CalculateBytes(byte[] src, byte[] key) {
            return GenericHash.CalculateBytes(src, () => new HMACMD5(key));
        }

        public static byte[] CalculateBytes(byte[] src, string key) {
            return GenericHash.CalculateBytes(src, () => new HMACMD5(Encoding.UTF8.GetBytes(key)));
        }

        public static byte[] CalculateBytes(string src, byte[] key) {
            return GenericHash.CalculateBytes(src, () => new HMACMD5(key));
        }

        public static byte[] CalculateBytes(string src, string key) {
            return GenericHash.CalculateBytes(src, () => new HMACMD5(Encoding.UTF8.GetBytes(key)));
        }

        public static string CalculateString(Stream src, byte[] key) {
            return GenericHash.CalculateString(src, () => new HMACMD5(key));
        }

        public static string CalculateString(Stream src, string key) {
            return GenericHash.CalculateString(src, () => new HMACMD5(Encoding.UTF8.GetBytes(key)));
        }

        public static string CalculateString(byte[] src, byte[] key) {
            return GenericHash.CalculateString(src, () => new HMACMD5(key));
        }

        public static string CalculateString(byte[] src, string key) {
            return GenericHash.CalculateString(src, () => new HMACMD5(Encoding.UTF8.GetBytes(key)));
        }

        public static string CalculateString(string src, byte[] key) {
            return GenericHash.CalculateString(src, () => new HMACMD5(key));
        }

        public static string CalculateString(string src, string key) {
            return GenericHash.CalculateString(src, () => new HMACMD5(Encoding.UTF8.GetBytes(key)));
        }

    }

}
