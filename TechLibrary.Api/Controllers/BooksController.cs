using Microsoft.AspNetCore.Mvc;
using TechLibrary.Api.Filters;
using TechLibrary.Api.UseCases.Books;

namespace TechLibrary.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet("Filter")]
        [ProducesResponseType(typeof(ResponseBooksJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseBooksJson), StatusCodes.Status204NoContent)]
        public IActionResult Filter(int pageNumber, string? title)
        {
            var useCase = new FilterBookUseCase();

            var request = new RequestFilterBooksJson
            {
                PageNumber = pageNumber,
                Title = title
            };

            var result = useCase.Execute(request);

            return Ok(result);
        }
    }
}
