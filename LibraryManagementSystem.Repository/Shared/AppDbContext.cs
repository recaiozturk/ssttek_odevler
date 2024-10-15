using LibraryManagementSystem.Repository.Authors;
using LibraryManagementSystem.Repository.Books;
using LibraryManagementSystem.Repository.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repository.Shared
{
    public class AppDbContext(DbContextOptions options) : IdentityDbContext<AppUser,AppRole,Guid>(options)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
