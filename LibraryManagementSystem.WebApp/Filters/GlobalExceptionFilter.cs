using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LibraryManagementSystem.WebApp.Filters
{
    public class GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger) : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            logger.LogError(exception, "Hata!");
            var result = new RedirectToActionResult("CustomError", "Home", new { message = exception.Message });

            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
