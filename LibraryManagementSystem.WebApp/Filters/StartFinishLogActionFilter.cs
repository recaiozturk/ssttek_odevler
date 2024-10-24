using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace LibraryManagementSystem.WebApp.Filters
{
    public class StartFinishLogActionFilter(ILogger<StartFinishLogActionFilter> logger) : IActionFilter
    {
        private Stopwatch _stopwatch;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerName = context.ActionDescriptor.RouteValues["controller"];
            var actionName = context.ActionDescriptor.RouteValues["action"];

            DateTime now = DateTime.Now;
            _stopwatch = Stopwatch.StartNew();
            logger.LogInformation($"{controllerName}.{actionName} aksiyonunun başlangıç zamanı {now:HH:mm:ss.fff}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var controllerName = context.ActionDescriptor.RouteValues["controller"];
            var actionName = context.ActionDescriptor.RouteValues["action"];

            DateTime now = DateTime.Now;
            _stopwatch.Stop();
            logger.LogInformation($"{controllerName}.{actionName} aksiyonunun bitiş zamanı {now:HH:mm:ss.fff} Geçen Süre: {_stopwatch.ElapsedMilliseconds} ms");

        }
    }
}
