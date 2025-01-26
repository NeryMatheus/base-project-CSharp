using base_project_CSharp.Domain.Repositories;
using base_project_CSharp.Domain.Repositories.User;
using base_project_CSharp.Infrastructure.DataAccess;
using base_project_CSharp.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace base_project_CSharp.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrasctructure(this IServiceCollection services)
        {
            AddRepositories(services);
            AddDbContext(services);
        }

        private static void AddDbContext(IServiceCollection services)
        {
            var connectionString = "Server=localhost,1455;Database=recipebook;User ID=sa;Password=Admin@123;Encrypt=True;TrustServerCertificate=True;";
            services.AddDbContext<RecipeBookDbContext>(dbContextOptions =>
            {
                dbContextOptions.UseSqlServer(connectionString);
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUserWriteRepositoryOnly, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
