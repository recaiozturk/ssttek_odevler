using AutoMapper;
using LibraryManagementSystem.Repository.Authors;
using LibraryManagementSystem.Repository.Shared;
using LibraryManagementSystem.Service.Authors.ViewModels;
using LibraryManagementSystem.Service.Shared;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Service.Authors
{
    public class AuthorService(IAuthorRepository authorRepository, IUnitOfWork unitOfWork, IMapper mapper) : IAuthorService
    {
        public async Task<ServiceResult<AuthorViewModel?>> GetAuthorWithBooksAsync(int id)
        {
            var authorWithbooks = await authorRepository.GetAuthorWithBooksAsync(id);
            var authorsAsModel = mapper.Map<AuthorViewModel>(authorWithbooks);
            return ServiceResult<AuthorViewModel?>.Success(authorsAsModel);
        }


        public async Task<ServiceResult<List<SelectListItem>>> GetAuthorsSelectListAsync()
        {
            var authorsSelectList = await authorRepository.GetAll()
            .Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            }).ToListAsync();

            return ServiceResult<List<SelectListItem>>.Success(authorsSelectList);
        }

        public async Task<ServiceResult<AuthorViewModel>> AddAsync(CreateAuthorViewModel authorCreateModel)
        {
            var newAuthor = mapper.Map<Author>(authorCreateModel);

            await authorRepository.AddAsync(newAuthor);
            await unitOfWork.CommitAsync();

            return ServiceResult<AuthorViewModel>.Success(mapper.Map<AuthorViewModel>(newAuthor));
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var author = await GetByIdAsync(id);
            if (author != null)
            {
                authorRepository.Remove(id);
                await unitOfWork.CommitAsync();

                return ServiceResult.Success();
            }

            return ServiceResult.Fail("Silinecek yazar bulunamadi");
        }

        public async Task<ServiceResult<List<AuthorViewModel>>>  GetAllAsync()
        {
            var authors = await authorRepository.GetAll().ToListAsync();
            var authorsAsModel = mapper.Map<List<AuthorViewModel>>(authors);

            return ServiceResult<List<AuthorViewModel>>.Success(authorsAsModel);
        }

        public async Task<ServiceResult<AuthorViewModel?>> GetByIdAsync(int id)
        {
            var author = await authorRepository.GetByIdAsync(id);
            if (author == null)
                return ServiceResult<AuthorViewModel?>.Fail("Yazar bulunamadi");

            return ServiceResult<AuthorViewModel?>.Success(mapper.Map<AuthorViewModel>(author));
        }

        public async Task<ServiceResult> UpdateAsync(UpdateAuthorViewModel authorUpdateModel)
        {
            var authorToUpdate = mapper.Map<Author>(authorUpdateModel);

            authorRepository.Update(authorToUpdate);
            await unitOfWork.CommitAsync();

            return ServiceResult.Success();
        }
    }
}
