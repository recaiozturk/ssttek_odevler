using LibraryManagementSystem.WebApp.Authors.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.WebApp.Authors.Services
{
    public interface IAuthorService
    {
        Task<AuthorViewModel?> GetAuthorWithBooksAsync(int id);
        Task<List<SelectListItem>> GetAuthorsSelectListAsync();
        Task<List<AuthorViewModel>> GetAllAsync();
        Task<AuthorViewModel?> GetByIdAsync(int id);
        Task<AuthorViewModel> AddAsync(CreateAuthorViewModel authorCreateModel);
        Task UpdateAsync(UpdateAuthorViewModel authorUpdateModel);
        Task DeleteAsync(int id);
    }
}
