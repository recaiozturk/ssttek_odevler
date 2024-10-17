using LibraryManagementSystem.Repository.Authors;
using LibraryManagementSystem.Repository.Books;
using LibraryManagementSystem.Repository.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repository.Shared
{
    public class AppDbContext(DbContextOptions options) : IdentityDbContext<AppUser,AppRole,Guid>(options)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedDefaultUserAndRoles(builder);
        }

        void SeedDefaultUserAndRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<Guid>>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            Guid ADMIN_ID = Guid.NewGuid();
            Guid ROLE_ID = Guid.NewGuid();
            Guid DEFAULT_ROLE_ID = Guid.NewGuid();

            //seed admin role
            builder.Entity<AppRole>().HasData(new AppRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID.ToString()
            });

            //seed default role
            builder.Entity<AppRole>().HasData(new AppRole
            {
                Name = "User",
                NormalizedName = "USER",
                Id = DEFAULT_ROLE_ID,
                ConcurrencyStamp = DEFAULT_ROLE_ID.ToString()
            });

            //create user
            var appUser = new AppUser
            {
                Id = ADMIN_ID,
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                UserName = "tesla54",
                NormalizedUserName = "TESLA54",
                SecurityStamp  = Guid.NewGuid().ToString()
            };

            //set user password
            PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "Password.123");

            //seed user
            builder.Entity<AppUser>().HasData(appUser);

            //set user role to admin
            builder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        }
    }
    
}
