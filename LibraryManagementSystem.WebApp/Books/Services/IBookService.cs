using LibraryManagementSystem.WebApp.Books.Models;

namespace LibraryManagementSystem.WebApp.Books.Services
{
    public interface IBookService
    {
        Task<BookViewModel?> GetBookWithAuthorAsync(int id);
        Task<List<BookViewModel>> GetAllAsync();
        Task<BookListModel> PrepareListPageAsync(int pageNumber, int pageSize);
        Task<BookViewModel?> GetByIdAsync(int id);
        Task<BookViewModel> AddAsync(CreateBookViewModel bookCreateModel);
        Task UpdateAsync(UpdateBookViewModel bookUpdateModel);
        Task DeleteAsync(int id);
    }
}
