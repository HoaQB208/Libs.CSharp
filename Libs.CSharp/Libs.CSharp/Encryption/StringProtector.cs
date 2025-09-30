using System;
using System.Text;

namespace Libs.CSharp.Encryption
{
    public class StringProtector
    {
        public static string Encrypt(string input, string seed = "hoa.pham")
        {
            var data = Encoding.UTF8.GetBytes(input);
            if (!string.IsNullOrEmpty(seed))
            {
                var key = Encoding.UTF8.GetBytes(seed);
                for (int i = 0; i < data.Length; i++)
                    data[i] ^= key[i % key.Length];
            }
            return Convert.ToBase64String(data);
        }

        public static string Decrypt(string input, string seed = "hoa.pham")
        {
            var data = Convert.FromBase64String(input);
            if (!string.IsNullOrEmpty(seed))
            {
                var key = Encoding.UTF8.GetBytes(seed);
                for (int i = 0; i < data.Length; i++)
                    data[i] ^= key[i % key.Length];
            }
            return Encoding.UTF8.GetString(data);
        }
    }
}
