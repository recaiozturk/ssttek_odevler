using LibraryManagementSystem.Service.Books.ViewModels;
using LibraryManagementSystem.Service.Shared;
using LibraryManagementSystem.Service.Shared.Models;

namespace LibraryManagementSystem.Service.Books
{
    public interface IBookService
    {
        Task<ServiceResult<CustomJsonModel>> GetSearchedBooksAsync(string searchValue);
        Task<ServiceResult<BookViewModel?>> GetBookWithAuthorAsync(int id);
        Task<ServiceResult<List<BookViewModel>>> GetAllAsync();
        Task<ServiceResult<BookListModel>> PrepareListPageAsync(int pageNumber, int pageSize);
        Task<ServiceResult<BookViewModel?>> GetByIdAsync(int id);
        Task<ServiceResult<BookViewModel>> AddAsync(CreateBookViewModel bookCreateModel);
        Task<ServiceResult> UpdateAsync(UpdateBookViewModel bookUpdateModel);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
