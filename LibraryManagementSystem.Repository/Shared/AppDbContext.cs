using LibraryManagementSystem.Repository.Authors;
using LibraryManagementSystem.Repository.Books;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repository.Shared
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
