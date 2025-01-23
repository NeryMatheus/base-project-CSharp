﻿using System.Security.Cryptography;
using System.Text;

namespace base_project_CSharp.Application.Cryptography
{
    public class PasswordEncripter
    {
        public string Encrypt(string password)
        {
            var addictionalKey = "ABC";
            string newPassword = $"{password}{addictionalKey}";

            var bytes = Encoding.UTF8.GetBytes(password);
            var hashBytes = SHA512.HashData(bytes);

            return StringBytes(hashBytes);
        }

        public static string StringBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
    }
}
