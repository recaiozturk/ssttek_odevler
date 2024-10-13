using LibraryManagementSystem.Service.Books.ViewModels;
using LibraryManagementSystem.Service.Shared.Models;

namespace LibraryManagementSystem.Service.Books
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
