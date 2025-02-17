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
        public UserController(IRegisterUserUseCase useCase) { }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> RegisterUser(
            [FromServices] IRegisterUserUseCase useCase,
            [FromBody] RequestRegisterUserJson request)
        {
            var result = await useCase.RegisterUser(request);
            return Created(string.Empty, result);
        }
    }
}
