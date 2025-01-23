using base_project_CSharp.Application.Cryptography;
using base_project_CSharp.Application.Services.AutoMapper;
using base_project_CSharp.Communication.Requests;
using base_project_CSharp.Communication.Responses;
using base_project_CSharp.Domain.Entities;
using base_project_CSharp.Exceptions.ExceptionBase;

namespace base_project_CSharp.Application.UseCases.User.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisterUserJson RegisterUser(RequestRegisterUserJson request)
        {
            var encrypter = new PasswordEncripter();
            var autoMapper = new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper();

            Validate(request);

            var user = autoMapper.Map<UserEntity>(request);
            user.Password = encrypter.Encrypt(request.Password);

            return new ResponseRegisterUserJson
            {
                Name = request.Name,
            };
        }

        public void Validate(RequestRegisterUserJson request) {
            var validator = new RegisterUserValidator();
            var result = validator.Validate(request);

            if (result.IsValid == false) { 
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
