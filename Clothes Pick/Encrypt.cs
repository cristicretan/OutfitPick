using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Clothes_Pick
{
    public class Encrypt
    {
        public static string SHA128(string input)
        {
            SHA1 SHA128_hash = SHA1.Create();
            byte[] data = SHA128_hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public static string GenerateRandomSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[128];
            rng.GetBytes(buffer);
            string salt = BitConverter.ToString(buffer);
            salt = Encrypt.SHA128(salt);
            return salt;
        }
    }
}
