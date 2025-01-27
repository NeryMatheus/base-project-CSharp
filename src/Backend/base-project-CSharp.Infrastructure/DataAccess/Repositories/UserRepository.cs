using base_project_CSharp.Domain.Entities;
using base_project_CSharp.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace base_project_CSharp.Infrastructure.DataAccess.Repositories
{
    public class UserRepository : IUserReadOnlyRepository, IUserWriteRepositoryOnly
    {
        private readonly RecipeBookDbContext _dbContext;
        public UserRepository(RecipeBookDbContext dbContext) => _dbContext = dbContext;
        public async Task Add(UserEntity user) => await _dbContext.AddAsync(user);
        public async Task<bool> ExistActiveUserWithEmail(string email) => await _dbContext.Users.AnyAsync(user => user.Email.Equals(email) && user.Active);
    }
}
