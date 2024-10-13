using LibraryManagementSystem.Service.Authors.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.Service.Authors
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
