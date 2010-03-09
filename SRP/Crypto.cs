// srp4net 1.0
// SRP for .NET - A JavaScript/C# .NET library for implementing the SRP authentication protocol
// by Sorin Ostafiev (http://code.google.com/p/srp4net/)
// License: LGPL v3 (http://www.gnu.org/licenses/lgpl-3.0.txt)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace srp4net.Helpers
{
    public enum HashAlgorithm
    {
        SHA512 = 1
    }

    public abstract partial class Crypto
    {
        public static HashAlgorithm DefaultHashAlgorithm = HashAlgorithm.SHA512;

        public static byte[] Hash(HashAlgorithm alg, byte[] message)
        {
            switch (alg)
            {
                case HashAlgorithm.SHA512:
                    return SHA512.Hash(message);
                default:
                    throw new Exception("Invalid HashAlgorithm");
            }
        }

        public int HashAlgorithmId
        {
            get
            {
                return (int)DefaultHashAlgorithm;
            }
        }

        public static string Hash(string message)
        {
            return
                Hex.ByteArrayToHexString(
                    Hash(
                        DefaultHashAlgorithm,
                        UTF8.StringToByteArray(message)));
        }


        public static string HashHex(string hexmessage)
        {
            return
                Hex.ByteArrayToHexString(
                    Hash(
                        DefaultHashAlgorithm,
                        Hex.HexStringToByteArray(hexmessage)));
        }
    }
}
