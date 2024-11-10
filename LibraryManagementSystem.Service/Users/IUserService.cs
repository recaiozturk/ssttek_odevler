using LibraryManagementSystem.Service.Shared;
using LibraryManagementSystem.Service.Users.DTOs;

namespace LibraryManagementSystem.Service.Users
{
    public interface IUserService
    {
        Task<ApiServiceResult<Guid>> CreateUserAsync(CreateUserRequest request);
        Task<ApiServiceResult> UpdateUserAsync(UpdateUserRequest request);
        Task<ApiServiceResult<UserResponse>> GetUserAsync(string userId);
        Task<ApiServiceResult> DeleteUserAsync(string userId);
    }
}
