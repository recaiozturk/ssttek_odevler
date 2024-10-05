using AutoMapper;
using LibraryManagementSystem.WebApp.Authors.Entities;
using LibraryManagementSystem.WebApp.Authors.Models;
using LibraryManagementSystem.WebApp.Authors.Repository;
using LibraryManagementSystem.WebApp.Shared.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.WebApp.Authors.Services
{
    public class AuthorService(IAuthorRepository authorRepository, IUnitOfWork unitOfWork, IMapper mapper) : IAuthorService
    {
        public async Task<AuthorViewModel?> GetAuthorWithBooksAsync(int id)
        {
            var authorWithbooks=await authorRepository.GetAuthorWithBooksAsync(id);
            var authorsAsModel = mapper.Map<AuthorViewModel>(authorWithbooks);
            return authorsAsModel;
        }
        public async Task<List<SelectListItem>> GetAuthorsSelectListAsync()
        {
            var authorsSelectList = await authorRepository.GetAll()
            .Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            }).ToListAsync();

            return authorsSelectList;

        }

        public async Task<AuthorViewModel> AddAsync(CreateAuthorViewModel authorCreateModel)
        {
            var newAuthor = mapper.Map<Author>(authorCreateModel);

            await authorRepository.AddAsync(newAuthor);
            await unitOfWork.CommitAsync();

            return mapper.Map<AuthorViewModel>(newAuthor);
        }

        public async Task DeleteAsync(int id)
        {
            var author = await GetByIdAsync(id);
            if (author != null)
            {
                authorRepository.Remove(id);
                await unitOfWork.CommitAsync();
            }
        }

        public async Task<List<AuthorViewModel>> GetAllAsync()
        {
            var authors = await authorRepository.GetAll().ToListAsync();

            var authorsAsModel = mapper.Map<List<AuthorViewModel>>(authors);

            return authorsAsModel;
        }

        public async Task<AuthorViewModel?> GetByIdAsync(int id)
        {
            var author = await authorRepository.GetByIdAsync(id);
            if (author == null)
                return null;
            return mapper.Map<AuthorViewModel>(author);
        }

        public async Task UpdateAsync(UpdateAuthorViewModel authorUpdateModel)
        {
            var authorToUpdate = mapper.Map<Author>(authorUpdateModel);

            authorRepository.Update(authorToUpdate);
            await unitOfWork.CommitAsync();
        }
    }
}
