using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;

namespace TechLibrary.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is TechLibraryException ex)
            {
                context.HttpContext.Response.StatusCode = (int)ex.GetStatusCode();
                context.Result = new ObjectResult(new ResponseErrorMessageJson
                {
                    Errors = ex.GetErrorMessages()
                });
            }
            else
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Result = new ObjectResult(new ResponseErrorMessageJson
                {
                    Errors = ["Unknown error!"]
                });
            }
        }
    }
}
