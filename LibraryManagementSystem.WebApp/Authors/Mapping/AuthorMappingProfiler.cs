using AutoMapper;
using LibraryManagementSystem.WebApp.Authors.Entities;
using LibraryManagementSystem.WebApp.Authors.Models;

namespace LibraryManagementSystem.WebApp.Books.Mapping
{
    public class AuthorMappingProfiler : Profile
    {
        public AuthorMappingProfiler()
        {
            CreateMap<AuthorViewModel, Author>().ReverseMap();
            CreateMap<Author, CreateAuthorViewModel>().ReverseMap();
            CreateMap<Author, UpdateAuthorViewModel>().ReverseMap();
            CreateMap<AuthorViewModel, UpdateAuthorViewModel>().ReverseMap();
            CreateMap<Author, Author>();
        }

    }
}
