using LibraryManagementSystem.Service.Authors;
using LibraryManagementSystem.Service.Books;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementSystem.Service.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServicesExt(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();

            return services;
        }
    }
}
