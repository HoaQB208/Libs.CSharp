using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Libs.CSharp.Encryption
{
    public class SHAHelper
    {
        public static async Task<string> SHA1(string filePath)
        {
            return await Task.Run(() =>
            {
                using (SHA1Managed sha1 = new SHA1Managed())
                {
                    try
                    {
                        var allBytes = File.ReadAllBytes(filePath);
                        byte[] hash = sha1.ComputeHash(allBytes);
                        StringBuilder sb = new StringBuilder(hash.Length * 2);
                        foreach (byte b in hash)
                        {
                            sb.Append(b.ToString("x2"));
                        }
                        return sb.ToString();
                    }
                    catch { }
                    return "";
                }
            });
        }

        public static bool IsSHA1(string input)
        {
            if (input.Length != 40) return false;
            foreach (char c in input)
            {
                if (!((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F'))) return false;
            }
            return true;
        }
    }
}
