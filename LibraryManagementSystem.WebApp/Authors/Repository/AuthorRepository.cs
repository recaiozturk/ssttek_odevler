using LibraryManagementSystem.WebApp.Authors.Entities;
using LibraryManagementSystem.WebApp.Shared.Repository;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.WebApp.Authors.Repository
{
    public class AuthorRepository(AppDbContext context) : GenericRepository<Author>(context), IAuthorRepository
    {
        public async Task<Author?> GetAuthorWithBooksAsync(int id)
        {
            var authorWithBooks = context.Authors.Include(b => b.Books).FirstOrDefault(x => x.Id == id);

            return authorWithBooks;
        }
    }
}
