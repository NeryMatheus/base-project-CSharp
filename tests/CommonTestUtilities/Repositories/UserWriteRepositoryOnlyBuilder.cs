using base_project_CSharp.Domain.Repositories.User;
using Moq;

namespace CommonTestUtilities.Repositories
{
    public class UserWriteRepositoryOnlyBuilder
    {
        public static IUserWriteRepositoryOnly Build()
        {
            var mock = new Mock<IUserWriteRepositoryOnly>();

            return mock.Object;
        }
    }
}
