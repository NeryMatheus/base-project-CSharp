using base_project_CSharp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace base_project_CSharp.Infrastructure.DataAccess
{
    public class BaseProjectContext : DbContext
    {
        public BaseProjectContext(DbContextOptions options) : base(options) { }
        public DbSet<UserEntity> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseProjectContext).Assembly);
        }
    }
}
