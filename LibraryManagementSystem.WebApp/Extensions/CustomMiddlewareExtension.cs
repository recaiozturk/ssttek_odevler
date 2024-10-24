using LibraryManagementSystem.WebApp.Middlewares;

namespace LibraryManagementSystem.WebApp.Extensions
{
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<IpBlockingMiddleware>();
            builder.UseMiddleware<RequestLoggingMiddleware>();

            //etkinleştirirsek headerda API-Key olmadıgı için siteye erişilemez
            //app.UseMiddleware<RequestHeaderMiddleware>();

            return builder;
        }
    }
}
