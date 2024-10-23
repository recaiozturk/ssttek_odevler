using FluentValidation;
using FluentValidation.AspNetCore;
using LibraryManagementSystem.Service.Books.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace LibraryManagementSystem.Service.Extensions
{
    public static class FluentExtension
    {
        public static IServiceCollection AddFluentExt(this IServiceCollection services, IConfiguration configuration)
        {
      
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining<CreateBookViewModelValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateBookViewModelValidator>();

            return services;
        }
    }
}
