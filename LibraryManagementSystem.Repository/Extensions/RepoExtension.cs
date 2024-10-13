using LibraryManagementSystem.Repository.Authors;
using LibraryManagementSystem.Repository.Books;
using LibraryManagementSystem.Repository.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementSystem.Repository.Extensions
{
    public static class RepoExtension
    {
        public static IServiceCollection AddRepoExt(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
