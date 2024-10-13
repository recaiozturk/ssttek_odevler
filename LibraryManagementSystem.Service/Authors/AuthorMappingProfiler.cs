using AutoMapper;
using LibraryManagementSystem.Repository.Authors;
using LibraryManagementSystem.Service.Authors.ViewModels;

namespace LibraryManagementSystem.Service.Authors
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
