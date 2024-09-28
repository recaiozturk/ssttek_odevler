using AutoMapper;
using LibraryManagementSystem.WebApp.Models;
using LibraryManagementSystem.WebApp.Models.ViewModels;
using LibraryManagementSystem.WebApp.Repository;
using LibraryManagementSystem.WebApp.Util;

namespace LibraryManagementSystem.WebApp.Services
{
    public class BookService(IBookRepository bookRepository,IMapper mapper) : IBookService
    {
        public List<BookViewModel> GetAll()
        {
            var books = bookRepository.GetAll();

            var booksAsModel=mapper.Map<List<BookViewModel>>(books);

            return booksAsModel;
        }

        public BookViewModel? GetById(int id)
        {
            var book = bookRepository.GetById(id);

            if (book == null)
            {
                return null;
            }

            //var test = mapper.Map<BookViewModel>(book);

            return mapper.Map<BookViewModel>(book);
        }

        public BookViewModel Add(CreateBookViewModel bookCreateModel)
        {
            if (bookCreateModel.ImageFile != null && bookCreateModel.ImageFile.Length > 0)
            {
                bookCreateModel.ImageUrl =  ImageHelper.AddImageAsync(bookCreateModel.ImageFile).Result;
            }

            var newBook =mapper.Map<Book>(bookCreateModel);
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

            var bookToUpdate=mapper.Map<Book>(bookUpdateModel);

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
