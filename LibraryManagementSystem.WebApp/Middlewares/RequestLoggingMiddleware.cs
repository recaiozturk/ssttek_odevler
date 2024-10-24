using System.Diagnostics;

namespace LibraryManagementSystem.WebApp.Middlewares
{
    public class RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            await next(context);

            stopwatch.Stop();

            var requestMethod = context.Request.Method;
            var requestUrl = context.Request.Path;
            var responseTime = stopwatch.ElapsedMilliseconds;

            logger.LogInformation($"Url: {requestUrl} - Method: {requestMethod} - Yanıt Süresi: {responseTime} ms");
        }
    }
}
