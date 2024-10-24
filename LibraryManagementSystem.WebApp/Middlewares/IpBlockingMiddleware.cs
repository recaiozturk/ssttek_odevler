namespace LibraryManagementSystem.WebApp.Middlewares
{
    public class IpBlockingMiddleware(RequestDelegate next)
    {
        private static readonly HashSet<string> BlockedIps = new HashSet<string>
        {
            "192.168.1.1",
            "203.0.113.0"
            //,"::1"
        };

        public async Task InvokeAsync(HttpContext context)
        {
            var remoteIp = context.Connection.RemoteIpAddress.ToString();

            if (BlockedIps.Contains(remoteIp))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden; 
                await context.Response.WriteAsync("IP adresiniz bloklandi ve erisiminiz engellendi!");
                return;
            }

            await next(context);
        }
    }
}
