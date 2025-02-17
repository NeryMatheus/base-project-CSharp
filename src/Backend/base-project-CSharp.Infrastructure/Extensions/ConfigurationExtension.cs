using Microsoft.Extensions.Configuration;

namespace base_project_CSharp.Infrastructure.Extensions
{
    public static class ConfigurationExtension
    {
        public static string ConnectionString(this IConfiguration configuration)
        {
            return configuration.GetConnectionString("Connection")!;
        }
    }
}
