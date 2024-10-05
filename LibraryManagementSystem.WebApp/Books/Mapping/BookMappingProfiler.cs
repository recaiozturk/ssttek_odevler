using AutoMapper;
using LibraryManagementSystem.WebApp.Books.Entities;
using LibraryManagementSystem.WebApp.Books.Models;

namespace LibraryManagementSystem.WebApp.Books.Mapping
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
