using base_project_CSharp.Application.UseCases.User.Register;
using base_project_CSharp.Communication.Requests;
using base_project_CSharp.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace base_project_CSharp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
        public IActionResult RegisterUser(RequestRegisterUserJson request)
        {
            var useCase = new RegisterUserUseCase();
            var result = useCase.RegisterUser(request);
            return Created(string.Empty, result);
        }
    }
}
