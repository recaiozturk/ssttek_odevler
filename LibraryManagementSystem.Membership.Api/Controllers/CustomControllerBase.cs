using LibraryManagementSystem.Service.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LibraryManagementSystem.Membership.Api.Controllers
{
    public class CustomControllerBase : ControllerBase
    {
        [NonAction]
        public IActionResult CreateObjectResult<T>(ApiServiceResult<T> result)
        {
            if (result.IsFail)
            {
                if (result.Status == HttpStatusCode.NotFound && result.Errors?.Count == 0)
                {
                    return NotFound();
                }


                var problemDetails = new ProblemDetails()
                {
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                    Title = "Bir hata oluştu",
                    Status = (int)result.Status,
                    Detail = result.Errors!.First()
                };


                return new ObjectResult(problemDetails)
                {
                    StatusCode = (int)result.Status
                };
            }

            return new ObjectResult(result.Data)
            {
                StatusCode = (int)result.Status
            };
        }

        [NonAction]
        public IActionResult CreateObjectResult(ApiServiceResult result)
        {
            if (result.IsFail)
            {
                if (result.Status == HttpStatusCode.NotFound && result.Errors?.Count==0)
                {
                    return NotFound();
                }


                var problemDetails = new ProblemDetails()
                {
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                    Title = "Bir hata oluştu",
                    Status = (int)result.Status,
                    Detail = result.Errors!.First()
                };


                return new ObjectResult(problemDetails)
                {
                    StatusCode = (int)result.Status
                };
            }

            return NoContent();
        }
    }
}
