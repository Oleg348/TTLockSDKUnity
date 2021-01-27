using System.Text;

using Newtonsoft.Json;

namespace OrbitaTech.TTLockUnity
{
    internal static class StringHelpers
    {
        public static string ToMD5(this string value)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                var inputBytes = Encoding.UTF8.GetBytes(value);
                var hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                var sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public static string SerializeToJson<T>(this T obj)
            where T : class
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T ParseJson<T>(this string jsonString)
            where T : class
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
