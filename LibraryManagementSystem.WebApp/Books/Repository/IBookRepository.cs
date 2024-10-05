using LibraryManagementSystem.WebApp.Books.Entities;
using LibraryManagementSystem.WebApp.Shared.Repository;

namespace LibraryManagementSystem.WebApp.Books.Repository
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<List<Book>> GetPaginationListAsync(int pageNumber, int pageSize);
        Task<Book> GetBookWithAuthorAsync(int id);
    }
}
