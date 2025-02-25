using base_project_CSharp.Domain.Repositories;
using base_project_CSharp.Domain.Repositories.User;
using base_project_CSharp.Infrastructure.DataAccess;
using base_project_CSharp.Infrastructure.DataAccess.Repositories;
using base_project_CSharp.Infrastructure.Extensions;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace base_project_CSharp.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrasctructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepositories(services, configuration);
            
            if (configuration.IsUnitTestEnviroment())
                return;

            AddDbContext(services, configuration);
            AddFluentMigrator_SQLServer(services, configuration);
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.ConnectionString();
            services.AddDbContext<BaseProjectContext>(dbContextOptions =>
            {
                dbContextOptions.UseSqlServer(connectionString);
            });
        }

        private static void AddRepositories(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUserWriteRepositoryOnly, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void AddFluentMigrator_SQLServer(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.ConnectionString();

            services.AddFluentMigratorCore().ConfigureRunner(options =>
            {
                options
                 .AddSqlServer()
                 .WithGlobalConnectionString(connectionString)
                 .ScanIn(Assembly.Load("base-project-CSharp.Infrastructure")).For.All();
            });
        }
    }
}
