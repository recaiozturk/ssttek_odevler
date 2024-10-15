using LibraryManagementSystem.Repository.Shared;
using LibraryManagementSystem.Repository.Users;
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

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.User.RequireUniqueEmail = true;
            })
    .AddEntityFrameworkStores<AppDbContext>();

            return services;
        }
    }
}
