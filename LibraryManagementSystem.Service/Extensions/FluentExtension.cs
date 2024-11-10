using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;



namespace LibraryManagementSystem.Service.Extensions
{
    public static class FluentExtension
    {
        public static IServiceCollection AddFluentExt(this IServiceCollection services, IConfiguration configuration)
        {
      
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //services.AddValidatorsFromAssemblyContaining<CreateBookViewModelValidator>();
            //services.AddValidatorsFromAssemblyContaining<UpdateBookViewModelValidator>();

            return services;
        }
    }
}
