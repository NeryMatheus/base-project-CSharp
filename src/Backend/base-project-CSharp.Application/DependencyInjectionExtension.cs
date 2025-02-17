using base_project_CSharp.Application.Cryptography;
using base_project_CSharp.Application.Services.AutoMapper;
using base_project_CSharp.Application.UseCases.User.Register;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace base_project_CSharp.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            AddAutoMapping(services);
            AddEncripter(services, configuration);
            AddUseCases(services);
        }

        private static void AddAutoMapping(IServiceCollection services)
        {
            services.AddScoped(options => new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper());
        }

        private static void AddEncripter(IServiceCollection services, IConfiguration configuration)
        {
            var addictionalKey = configuration.GetValue<string>("Settings:Password:AddictionalKey");
            services.AddScoped(options => new PasswordEncripter(addictionalKey!));
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        }
    }
}
