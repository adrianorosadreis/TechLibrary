using Microsoft.AspNetCore.Mvc;
using TechLibrary.Api.UseCases.Login;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;

namespace TechLibrary.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status401Unauthorized)]
        public IActionResult Login(RequestLoginJson request)
        {
            var useCase = new LoginUseCase();

            var response = useCase.Execute(request);

            return Ok(response);
        }
    }
}
