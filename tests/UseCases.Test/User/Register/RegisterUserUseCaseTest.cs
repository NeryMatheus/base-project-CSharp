using base_project_CSharp.Application.UseCases.User.Register;
using base_project_CSharp.Exceptions;
using base_project_CSharp.Exceptions.ExceptionBase;
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

        [Fact]
        public async Task Error_Email_Already_Registered()
        {
            var request = RequestRegisterUserJsonBuilder.Build();
            var useCase = CreateUseCase(request.Email);

            Func<Task> act = async () => await useCase.RegisterUser(request);

            var exception = await act.ShouldThrowAsync<ErrorOnValidationException>();
            exception.ErrorsMessages.Count.ShouldBe(1);
            exception.ErrorsMessages.ShouldContain(ResourceMessagesExceptions.EMAIL_ALREADY_EXIST);
        }

        [Fact]
        public async Task Error_Name_Empty()
        {
            var request = RequestRegisterUserJsonBuilder.Build();
            request.Name = string.Empty;

            var useCase = CreateUseCase();

            Func<Task> act = async () => await useCase.RegisterUser(request);

            var exception = await act.ShouldThrowAsync<ErrorOnValidationException>();
            exception.ErrorsMessages.Count.ShouldBe(1);
            exception.ErrorsMessages.ShouldContain(ResourceMessagesExceptions.NAME_EMPTY);
        }

        private RegisterUserUseCase CreateUseCase(string? email = null)
        {
            var writeOnly = UserWriteRepositoryOnlyBuilder.Build();
            var readOnlyBuilder = new UserReadOnlyRepositoryBuilder();
            var mapper = MapperBuilder.Build();
            var passwordEncipter = PasswordEncripterBuilder.Build();
            var unitOfWork = UnitOfWorkBuilder.Build();

            if (string.IsNullOrEmpty(email) == false)
                readOnlyBuilder.ExistActiveUserWithEmail(email);


            return new RegisterUserUseCase(writeOnly, readOnlyBuilder.Build(), mapper, passwordEncipter, unitOfWork);
        }
    }
}
