using base_project_CSharp.Application.UseCases.User.Register;
using CommonTestUtilities.Criptography;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using Shouldly;

namespace UseCases.Test.User.Register
{
    public class RegisterUserUseCaseTest
    {
        [Fact]
        public async Task Success()
        {
            var request = RequestRegisterUserJsonBuilder.Build();

            var useCase = CreateUseCase();
            
            var result = await useCase.RegisterUser(request);

            result.ShouldNotBeNull();
            result.Name.ShouldBe(request.Name);
        }

        private RegisterUserUseCase CreateUseCase()
        {
            var writeOnly = UserWriteRepositoryOnlyBuilder.Build();
            var readOnly = new UserReadOnlyRepositoryBuilder().Build();
            var mapper = MapperBuilder.Build();
            var passwordEncipter = PasswordEncripterBuilder.Build();
            var unitOfWork = UnitOfWorkBuilder.Build();
            
            return new RegisterUserUseCase(writeOnly, readOnly, mapper, passwordEncipter, unitOfWork);
        }
    }
}
