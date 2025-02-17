using base_project_CSharp.Domain.Entities;

namespace base_project_CSharp.Domain.Repositories.User
{
    public interface IUserWriteRepositoryOnly
    {
        public Task Add(UserEntity user);
    }
}
