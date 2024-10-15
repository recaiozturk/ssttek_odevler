using AutoMapper;
using LibraryManagementSystem.Repository.Users;
using LibraryManagementSystem.Service.Shared;
using LibraryManagementSystem.Service.Users.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Service.Users
{
    public class AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,IMapper mapper) : IAuthService
    {
        public Task<ServiceResult> SignIn(SignInViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult> SignUp(SignUpViewModel viewModel)
        {
            //var appUser = new AppUser
            //{
            //    UserName = viewModel.UserName,
            //    Email = viewModel.Email,
            //    City = viewModel.City
            //};

            var appUser = mapper.Map<AppUser>(viewModel);


            var result = await userManager.CreateAsync(appUser, viewModel.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return ServiceResult.Fail(errors);
            }

            return ServiceResult.Success();
        }
    }
}
