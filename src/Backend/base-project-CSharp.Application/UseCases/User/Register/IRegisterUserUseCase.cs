using base_project_CSharp.Communication.Requests;
using base_project_CSharp.Communication.Responses;

namespace base_project_CSharp.Application.UseCases.User.Register
{
    public interface IRegisterUserUseCase
    {
        public Task<ResponseRegisterUserJson> RegisterUser(RequestRegisterUserJson request);
    }
}
