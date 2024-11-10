using LibraryManagementSystem.Repository.Users;
using LibraryManagementSystem.Service.Shared;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Service.Roles
{
    public interface IRoleService
    {
        Task<ApiServiceResult<Guid>> CreateRoleAsync(string roleName);
        Task<ApiServiceResult<List<AppRole>>> GetRolesAsync();
        Task<ApiServiceResult> UpdateRoleAsync(string roleId, string newRoleName);
        Task<ApiServiceResult> DeleteRoleAsync(string roleId);
        Task<ApiServiceResult> AssignRoleToUserAsync(string roleId, string newRoleName);
        Task<ApiServiceResult> RemoveRoleFromUser(string userId, string roleName);
    }
}
