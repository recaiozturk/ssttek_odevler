using AutoMapper;
using LibraryManagementSystem.Repository.Books;
using LibraryManagementSystem.Service.Books.ViewModels;

namespace LibraryManagementSystem.Service.Books
{
    public class BookMappingProfiler : Profile
    {
        public BookMappingProfiler()
        {
            CreateMap<BookViewModel, Book>().ReverseMap();
            CreateMap<Book, CreateBookViewModel>().ReverseMap();
            CreateMap<Book, UpdateBookViewModel>().ReverseMap();
            CreateMap<BookViewModel, UpdateBookViewModel>().ReverseMap();
            CreateMap<Book, Book>();
        }

    }
}
