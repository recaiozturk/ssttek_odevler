using AutoMapper;
using LibraryManagementSystem.WebApp.Authors.Repository;
using LibraryManagementSystem.WebApp.Books.Entities;
using LibraryManagementSystem.WebApp.Books.Models;
using LibraryManagementSystem.WebApp.Books.Repository;
using LibraryManagementSystem.WebApp.Shared.Repository;
using LibraryManagementSystem.WebApp.Util;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.WebApp.Books.Services
{
    public class BookService(IBookRepository bookRepository,IAuthorRepository autherRepository,IUnitOfWork unitOfWork, IMapper mapper) : IBookService
    {
        public async Task<List<BookViewModel>> GetAllAsync()
        {
            var books = await bookRepository.GetAll().ToListAsync();

            var booksAsModel = mapper.Map<List<BookViewModel>>(books);

            return booksAsModel;
        }

        public async Task<BookViewModel?> GetBookWithAuthorAsync(int id)
        {
            var book = await bookRepository.GetBookWithAuthorAsync(id);
            if (book == null)
                return null;
            return mapper.Map<BookViewModel>(book);
        }

        

        public async Task<BookListModel> PrepareListPageAsync(int pageNumber, int pageSize)
        {
            var books = await bookRepository.GetPaginationListAsync(pageNumber, pageSize);
            var booksAsModel = mapper.Map<List<BookViewModel>>(books);

            BookListModel model = new();
            model.Books = booksAsModel;
            model.TotalPages = (int)Math.Ceiling(bookRepository.GetAll().Count() / (double)pageSize);

            return model;
        }

        public async Task<BookViewModel?> GetByIdAsync(int id)
        {
            var book = await bookRepository.GetByIdAsync(id);
            if (book == null)
                return null;
            return mapper.Map<BookViewModel>(book);
        }

        public async Task<BookViewModel> AddAsync(CreateBookViewModel bookCreateModel)
        {
            if (bookCreateModel.ImageFile != null && bookCreateModel.ImageFile.Length > 0)
                bookCreateModel.ImageUrl = ImageHelper.AddImageAsync(bookCreateModel.ImageFile).Result;

            var newBook = mapper.Map<Book>(bookCreateModel);
            newBook.Author = await autherRepository.GetByIdAsync(newBook.AuthorId);

            await bookRepository.AddAsync(newBook);
            await unitOfWork.CommitAsync();

            return mapper.Map<BookViewModel>(newBook);
        }

        public async Task UpdateAsync(UpdateBookViewModel bookUpdateModel)
        {
            if (bookUpdateModel.ImageFile != null && bookUpdateModel.ImageFile.Length > 0)
            {
                ImageHelper.DeleteOldImage(bookUpdateModel.ImageUrl);
                bookUpdateModel.ImageUrl = ImageHelper.AddImageAsync(bookUpdateModel.ImageFile).Result;
            }

            var bookToUpdate = mapper.Map<Book>(bookUpdateModel);
            bookToUpdate.Author = await autherRepository.GetByIdAsync(bookToUpdate.AuthorId);

            bookRepository.Update(bookToUpdate);
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await GetByIdAsync(id);
            if (book != null)
            {
                ImageHelper.DeleteOldImage(book.ImageUrl);
                bookRepository.Remove(id);
                await unitOfWork.CommitAsync();
            }
        }
    }
}
