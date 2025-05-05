using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Models.Extensions
{
    public static class StringExetions
    {
        public static string GetSHA256Hash(this string item)
        {
            var hash = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(item));
            var sd = new StringBuilder();
            foreach (var t in hash)
            {
                sd.Append(t.ToString("2x"));
            }
            return sd.ToString().ToLower();
        }   

    }

}
