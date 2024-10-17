using AutoMapper;
using LibraryManagementSystem.Repository.Users;
using LibraryManagementSystem.Service.Shared;
using LibraryManagementSystem.Service.Users.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Service.Users
{
    public class AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,RoleManager<AppRole> roleManager,IMapper mapper) : IAuthService
    {

        public async Task<ServiceResult> SignUp(SignUpViewModel viewModel)
        {
            var appUser = mapper.Map<AppUser>(viewModel);


            var result = await userManager.CreateAsync(appUser, viewModel.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return ServiceResult.Fail(errors);
            }

            await userManager.AddToRoleAsync(appUser, "User");

            return ServiceResult.Success();
        }

        public async Task<ServiceResult> SignIn(SignInViewModel viewModel)
        {
            var user = await userManager.FindByEmailAsync(viewModel.Email);

            if (user == null)
            {
                return ServiceResult.Fail(new List<string> { "Email veya Şifre yanlış" });
            }

            var result = await userManager.CheckPasswordAsync(user, viewModel.Password);

            if (!result)
            {
                return ServiceResult.Fail(new List<string> { "Email veya Şifre yanlış" });
            }

            await signInManager.SignInAsync(user, true);

            return ServiceResult.Success();
        }

        public async Task<ServiceResult> SignOut()
        {
            await signInManager.SignOutAsync();

            return ServiceResult.Success();
        }

        public async Task<ServiceResult<UpdateProfileViewModel>> GetProfileInfo(string username)
        {
            var currentUser = (await userManager.FindByNameAsync(username))!;

            var userEditViewModel = new UpdateProfileViewModel()
            {
                UserName = currentUser.UserName!,
                Email = currentUser.Email!,
                City = currentUser.City!,
            };

            return ServiceResult<UpdateProfileViewModel>.Success(userEditViewModel);
        }

        public async Task<ServiceResult> UpdateProfile(UpdateProfileViewModel viewModel,string currentUserName)
        {
            var currentUser = (await userManager.FindByNameAsync(currentUserName))!;

            currentUser.UserName= viewModel.UserName;
            currentUser.Email= viewModel.Email;
            currentUser.City= viewModel.City;

            var updateToUserResult = await userManager.UpdateAsync(currentUser);

            if(!updateToUserResult.Succeeded)
                return ServiceResult.Fail((List<string>)updateToUserResult.Errors);

            return ServiceResult.Success();
        }

        public async Task<ServiceResult> ChangePassword(ChangePasswordViewModel viewModel, string currentUserName)
        {
            var currentUser = (await userManager.FindByNameAsync(currentUserName))!;

            var checkOldPassword = await userManager.CheckPasswordAsync(currentUser, viewModel.OldPassword);

            if (!checkOldPassword)
                return ServiceResult.Fail("Eski şifreniz yanlış");

            var resultChangePassword = await userManager.ChangePasswordAsync(currentUser, viewModel.OldPassword, viewModel.Password);

            if (!resultChangePassword.Succeeded)
                return ServiceResult.Fail((List<string>)resultChangePassword.Errors);

            return ServiceResult.Success();
        }
    }
}
