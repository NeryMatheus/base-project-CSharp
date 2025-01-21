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
            return null;
        }
    }
}
