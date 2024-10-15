using AutoMapper;
using LibraryManagementSystem.Repository.Authors;
using LibraryManagementSystem.Repository.Books;
using LibraryManagementSystem.Repository.Shared;
using LibraryManagementSystem.Service.Books.ViewModels;
using LibraryManagementSystem.Service.Shared;
using LibraryManagementSystem.Service.Shared.Models;
using LibraryManagementSystem.Service.Util;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Service.Books
{
    public class BookService(IBookRepository bookRepository, IAuthorRepository autherRepository, IUnitOfWork unitOfWork, IMapper mapper) : IBookService
    {
        public async Task<ServiceResult<CustomJsonModel>> GetSearchedBooksAsync(string searchValue)
        {
            CustomJsonModel jsonModel= new CustomJsonModel();

            if (string.IsNullOrEmpty(searchValue))
            {
                jsonModel.IsValid = false;
                jsonModel.ErrorMessage = "Arama değeri boş olamaz";

                return ServiceResult<CustomJsonModel>.Success(jsonModel);

            }

            IQueryable<Book> query = bookRepository.GetBooksWithAuthor();

            bool isNumeric = int.TryParse(searchValue, out int publicationYear);

            query = query.Where(b =>
                b.Title.Contains(searchValue) ||
                b.Author.Name.Contains(searchValue) ||
                b.Genre.Contains(searchValue) ||
                b.Publisher.Contains(searchValue) ||
                b.ISBN.Contains(searchValue) ||
                b.Publisher.Contains(searchValue) ||
                isNumeric && b.PublicationYear == publicationYear
            );

            var result = await query.ToListAsync();

            if (result.Count > 0)
            {
                jsonModel.IsValid = true;
                jsonModel.Data = result;
            }
            else
            {
                jsonModel.IsValid = false;
                jsonModel.ErrorMessage = "Aradığınız kriterlerde sonuç bulunamadı";
            }

            return ServiceResult<CustomJsonModel>.Success(jsonModel);

        }
        public async Task<ServiceResult<List<BookViewModel>>> GetAllAsync()
        {
            var books = await bookRepository.GetAll().ToListAsync();

            var booksAsModel = mapper.Map<List<BookViewModel>>(books);

            return ServiceResult<List<BookViewModel>>.Success(booksAsModel);
        }

        public async Task<ServiceResult<BookViewModel?>> GetBookWithAuthorAsync(int id)
        {
            var book = await bookRepository.GetBookWithAuthorAsync(id);
            if (book == null)
                return ServiceResult<BookViewModel?>.Fail("Kitap Bulunamadi");

            return ServiceResult<BookViewModel?>.Success(mapper.Map<BookViewModel>(book));
        }

        public async Task<ServiceResult<BookListModel>> PrepareListPageAsync(int pageNumber, int pageSize)
        {
            var books = await bookRepository.GetPaginationListAsync(pageNumber, pageSize);
            var booksAsModel = mapper.Map<List<BookViewModel>>(books);

            BookListModel model = new();
            model.Books = booksAsModel;
            model.TotalPages = (int)Math.Ceiling(bookRepository.GetAll().Count() / (double)pageSize);

            return ServiceResult<BookListModel>.Success(model);
        }

        public async Task<ServiceResult<BookViewModel?>> GetByIdAsync(int id)
        {
            var book = await bookRepository.GetByIdAsync(id);
            if (book == null)
                return ServiceResult<BookViewModel?>.Fail("Kitap Bulunamadi");

            return ServiceResult<BookViewModel?>.Success(mapper.Map<BookViewModel>(book));
        }

        public async Task<ServiceResult<BookViewModel>> AddAsync(CreateBookViewModel bookCreateModel)
        {
            if (bookCreateModel.ImageFile != null && bookCreateModel.ImageFile.Length > 0)
                bookCreateModel.ImageUrl = ImageHelper.AddImageAsync(bookCreateModel.ImageFile).Result;

            var newBook = mapper.Map<Book>(bookCreateModel);
            newBook.Author = await autherRepository.GetByIdAsync(newBook.AuthorId);

            await bookRepository.AddAsync(newBook);
            await unitOfWork.CommitAsync();

            return ServiceResult<BookViewModel>.Success(mapper.Map<BookViewModel>(newBook));
        }

        public async Task<ServiceResult> UpdateAsync(UpdateBookViewModel bookUpdateModel)
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

            return ServiceResult.Success();
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var book = await bookRepository.GetByIdAsync(id);

            if (book != null)
            {
                ImageHelper.DeleteOldImage(book.ImageUrl);
                bookRepository.Remove(id);
                await unitOfWork.CommitAsync();

                return ServiceResult.Success();
            }
            else
                return ServiceResult.Fail("Silinirken hata meydana geldi");
        }
    }
}
