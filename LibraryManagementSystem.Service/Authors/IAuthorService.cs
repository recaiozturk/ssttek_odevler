using LibraryManagementSystem.Service.Authors.ViewModels;
using LibraryManagementSystem.Service.Shared;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.Service.Authors
{
    public interface IAuthorService
    {
        Task<ServiceResult<AuthorViewModel?>> GetAuthorWithBooksAsync(int id);
        Task<ServiceResult<List<SelectListItem>>> GetAuthorsSelectListAsync();
        Task<ServiceResult<List<AuthorViewModel>>> GetAllAsync();
        Task<ServiceResult<AuthorViewModel?>> GetByIdAsync(int id);
        Task<ServiceResult<AuthorViewModel>> AddAsync(CreateAuthorViewModel authorCreateModel);
        Task<ServiceResult> UpdateAsync(UpdateAuthorViewModel authorUpdateModel);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
