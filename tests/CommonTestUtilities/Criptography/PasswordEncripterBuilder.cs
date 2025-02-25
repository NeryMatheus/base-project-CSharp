using base_project_CSharp.Application.Cryptography;

namespace CommonTestUtilities.Criptography
{
    public class PasswordEncripterBuilder
    {
        public static PasswordEncripter Build() => new PasswordEncripter("ABC1234");
    }
}
