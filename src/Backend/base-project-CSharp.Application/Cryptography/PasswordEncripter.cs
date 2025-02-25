using System.Security.Cryptography;
using System.Text;

namespace base_project_CSharp.Application.Cryptography
{
    public class PasswordEncripter
    {

        private readonly string _addictionalKey;
        public PasswordEncripter(string addictionalKey) => _addictionalKey = addictionalKey;
        public string Encrypt(string password)
        {
            string newPassword = $"{password}{_addictionalKey}";

            var bytes = Encoding.UTF8.GetBytes(newPassword);
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
