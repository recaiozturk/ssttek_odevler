using LibraryManagementSystem.WebApp.Authors.Entities;
using LibraryManagementSystem.WebApp.Books.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.WebApp.Shared.Repository
{
    public class AppDbContext(DbContextOptions options):DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
