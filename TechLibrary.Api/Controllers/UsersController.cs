using Microsoft.AspNetCore.Mvc;
using TechLibrary.Api.UseCases.Users;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;

namespace TechLibrary.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register(RequestUserJson request)
        {
            try
            {
                var useCase = new RegisteredUserUseCase();

                var response = useCase.Execute(request);

                return Created(string.Empty, response);
            }
            catch(TechLibraryException ex)
            {
                return BadRequest(new ResponseErrorMessageJson
                {
                    Errors = ex.GetErrorMessages()
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessageJson
                {
                    Errors = ["An error occurred while processing the request"]
                });
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Created();
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Created();
        }
    }
}
