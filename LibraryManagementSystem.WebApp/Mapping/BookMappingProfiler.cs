using AutoMapper;
using LibraryManagementSystem.WebApp.Models;
using LibraryManagementSystem.WebApp.Models.ViewModels;

namespace LibraryManagementSystem.WebApp.Mapping
{
    public class BookMappingProfiler: Profile
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
