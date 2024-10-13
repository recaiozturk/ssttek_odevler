using LibraryManagementSystem.Repository.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementSystem.Repository.Extensions
{
    public static class DbContextExtension
    {
        public static IServiceCollection AddEfCoreExt(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(x =>
            {
                var connectionString = configuration.GetConnectionString("SqlSever");
                x.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
