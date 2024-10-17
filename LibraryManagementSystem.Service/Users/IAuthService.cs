
using LibraryManagementSystem.Service.Shared;
using LibraryManagementSystem.Service.Users.ViewModels;

namespace LibraryManagementSystem.Service.Users
{
    public interface IAuthService
    {
        Task<ServiceResult> SignUp(SignUpViewModel viewModel);
        Task<ServiceResult> SignIn(SignInViewModel viewModel);
        Task<ServiceResult> SignOut();
        Task<ServiceResult<UpdateProfileViewModel>> GetProfileInfo(string username);
        Task<ServiceResult> UpdateProfile(UpdateProfileViewModel vieModel, string currentUserName);
        Task<ServiceResult> ChangePassword(ChangePasswordViewModel viewModel, string currentUserName);
    }
}
