using LibraryManagementSystem.WebApp.Books.Models;
using LibraryManagementSystem.WebApp.Shared.Models;

namespace LibraryManagementSystem.WebApp.Books.Services
{
    public interface IBookService
    {
        Task<CustomJsonModel> GetSearchedBooksAsync(string searchValue);
        Task<BookViewModel?> GetBookWithAuthorAsync(int id);
        Task<List<BookViewModel>> GetAllAsync();
        Task<BookListModel> PrepareListPageAsync(int pageNumber, int pageSize);
        Task<BookViewModel?> GetByIdAsync(int id);
        Task<BookViewModel> AddAsync(CreateBookViewModel bookCreateModel);
        Task UpdateAsync(UpdateBookViewModel bookUpdateModel);
        Task DeleteAsync(int id);
    }
}
