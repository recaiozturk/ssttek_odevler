using LibraryManagementSystem.Service.Authors;
using LibraryManagementSystem.Service.Books;
using LibraryManagementSystem.Service.Roles;
using LibraryManagementSystem.Service.Users;
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
            services.AddScoped<IAuthService,AuthService>();



            return services;
        }
    }
}
