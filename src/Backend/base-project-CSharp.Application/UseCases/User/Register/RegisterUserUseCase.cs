using base_project_CSharp.Communication.Requests;
using base_project_CSharp.Communication.Responses;
using base_project_CSharp.Exceptions.ExceptionBase;

namespace base_project_CSharp.Application.UseCases.User.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisterUserJson RegisterUser(RequestRegisterUserJson request)
        {
            Validate(request);

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
