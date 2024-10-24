using LibraryManagementSystem.WebApp.Filters;

namespace LibraryManagementSystem.WebApp.Extensions
{
    public static class FilterExtension
    {
        public static IServiceCollection AddMyFilterExt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<GlobalExceptionFilter>();
            });

            services.AddScoped<CustomAuthorizationFilter>();
            services.AddScoped<StartFinishLogActionFilter>();
            services.AddScoped<BooksCacheResourceFilter>();
            services.AddScoped<BookDetailResultFilter>();

            return services;
        }
    }
}
