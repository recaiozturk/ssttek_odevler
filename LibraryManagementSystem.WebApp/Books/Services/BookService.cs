using AutoMapper;
using LibraryManagementSystem.WebApp.Books.Entities;
using LibraryManagementSystem.WebApp.Books.Models;
using LibraryManagementSystem.WebApp.Books.Repository;
using LibraryManagementSystem.WebApp.Util;

namespace LibraryManagementSystem.WebApp.Books.Services
{
    public class BookService(IBookRepository bookRepository, IMapper mapper) : IBookService
    {
        public List<BookViewModel> GetAll()
        {
            var books = bookRepository.GetAll();

            var booksAsModel = mapper.Map<List<BookViewModel>>(books);

            return booksAsModel;
        }

        public BookListModel PrepareListPage(int pageNumber, int pageSize)
        {
            var books = bookRepository.GetPaginationList(pageNumber, pageSize);
            var booksAsModel = mapper.Map<List<BookViewModel>>(books);

            BookListModel model = new();
            model.Books = booksAsModel;
            model.TotalPages = (int)Math.Ceiling(bookRepository.GetAll().Count() / (double)pageSize);

            return model;
        }

        public BookViewModel? GetById(int id)
        {
            var book = bookRepository.GetById(id);

            if (book == null)
            {
                return null;
            }

            return mapper.Map<BookViewModel>(book);
        }

        public BookViewModel Add(CreateBookViewModel bookCreateModel)
        {
            if (bookCreateModel.ImageFile != null && bookCreateModel.ImageFile.Length > 0)
            {
                bookCreateModel.ImageUrl = ImageHelper.AddImageAsync(bookCreateModel.ImageFile).Result;
            }

            var newBook = mapper.Map<Book>(bookCreateModel);
            newBook.Id = GetAll().Count + 1;

            bookRepository.Add(newBook);

            return mapper.Map<BookViewModel>(newBook);
        }

        public void Update(UpdateBookViewModel bookUpdateModel)
        {
            if (bookUpdateModel.ImageFile != null && bookUpdateModel.ImageFile.Length > 0)
            {
                ImageHelper.DeleteOldImage(bookUpdateModel.ImageUrl);
                bookUpdateModel.ImageUrl = ImageHelper.AddImageAsync(bookUpdateModel.ImageFile).Result;
            }

            var bookToUpdate = mapper.Map<Book>(bookUpdateModel);

            bookRepository.Update(bookToUpdate);
        }

        public void Delete(int id)
        {
            var book = GetById(id);
            ImageHelper.DeleteOldImage(book.ImageUrl);

            bookRepository.Delete(id);
        }
    }
}
