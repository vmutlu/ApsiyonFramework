using System;
using System.Text;

namespace Apsiyon.Utilities.Security.Encryption
{
    /// <summary>
    /// This helper class that encrypts and decrypts texts
    /// </summary>
    public static class StringDataEncryptionHelper
    {
        /// <summary>
        /// Algorithm method that encrypts incoming string value
        /// </summary>
        /// <param name="text"></param>
        /// <param name="xorConstant"></param>
        /// <returns></returns>
        public static string EncryptString(string text, byte xorConstant)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            var data = Encoding.UTF8.GetBytes(text);

            for (int i = 0; i < data.Length; i++)
                data[i] = Convert.ToByte((data[i] ^ xorConstant));

            return Convert.ToBase64String(data);
        }

        /// <summary>
        /// Algorithm method that decrypts the incoming encrypted string value
        /// </summary>
        /// <param name="text"></param>
        /// <param name="xorConstant"></param>
        /// <returns></returns>
        public static string DecryptString(string text, byte xorConstant)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            byte[] data;
            data = Convert.FromBase64String(text);

            for (int i = 0; i < data.Length; i++)
                data[i] = Convert.ToByte((data[i] ^ xorConstant));

            return Encoding.UTF8.GetString(data);
        }
    }
}
