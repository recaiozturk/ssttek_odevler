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

        public async Task<ServiceResult> AddRoleToUser(string roleName, string userId)
        {
            var hasUser = await userManager.FindByIdAsync(userId);

            if (hasUser is null)
            {
                return ServiceResult.Fail("Kullanıcı bulunamadı");
            }


            var hasRole = await roleManager.FindByNameAsync(roleName);

            if (hasRole is null)
            {
                return ServiceResult.Fail("Rol bulunamadı");
            }


            var result = await userManager.AddToRoleAsync(hasUser, roleName);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return ServiceResult.Fail(errors);
            }

            return ServiceResult.Success();
        }
    }
}
