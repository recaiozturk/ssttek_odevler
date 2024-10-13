using LibraryManagementSystem.Repository.Shared;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repository.Authors
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
