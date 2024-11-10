using AutoMapper;
using LibraryManagementSystem.Repository.Users;
using LibraryManagementSystem.Service.Users.DTOs;
using LibraryManagementSystem.Service.Users.ViewModels;

namespace LibraryManagementSystem.Service.Authors
{
    public class UserrMappingProfiler : Profile
    {
        public UserrMappingProfiler()
        {
            CreateMap<SignUpViewModel, AppUser>().ReverseMap();

            CreateMap<AppUser,UserResponse>().ReverseMap();
            CreateMap<AppUser, CreateUserRequest>().ReverseMap();
            CreateMap<AppUser, UpdateUserRequest>().ReverseMap();
        }

    }
}
