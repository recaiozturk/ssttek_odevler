using LibraryManagementSystem.Repository.Shared;

namespace LibraryManagementSystem.Repository.Books
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<List<Book>> GetPaginationListAsync(int pageNumber, int pageSize);
        Task<Book> GetBookWithAuthorAsync(int id);
        IQueryable<Book> GetBooksWithAuthor();
    }
}
