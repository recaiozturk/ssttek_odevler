
using LibraryManagementSystem.Service.Shared;
using LibraryManagementSystem.Service.Users.ViewModels;

namespace LibraryManagementSystem.Service.Users
{
    public interface IAuthService
    {
        Task<ServiceResult> SignUp(SignUpViewModel viewModel);
        Task<ServiceResult> SignIn(SignInViewModel viewModel);
        Task<ServiceResult> SignOut();
        Task<ServiceResult> AddRoleToUser(string roleName, string userId);
    }
}
