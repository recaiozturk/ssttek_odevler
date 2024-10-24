namespace LibraryManagementSystem.WebApp.Middlewares
{
    public class RequestHeaderMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("API-Key"))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Erisim Engellendi: Tutarsiz Api-Key");
                return;
            }

            await next(context);
        }
    }
}
