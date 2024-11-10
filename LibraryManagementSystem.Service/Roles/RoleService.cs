using LibraryManagementSystem.Repository.Users;
using LibraryManagementSystem.Service.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LibraryManagementSystem.Service.Roles
{
    public class RoleService(RoleManager<AppRole> _roleManager,UserManager<AppUser> _userManager) : IRoleService
    {
        public async Task<ApiServiceResult<Guid>> CreateRoleAsync(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                return ApiServiceResult<Guid>.Fail("Rol ismi boş geçilemez",HttpStatusCode.BadRequest);

            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (roleExist)
                return ApiServiceResult<Guid>.Fail("Bu rol zaten kayitli", HttpStatusCode.BadRequest);

            var newRole = new AppRole { Name = roleName };
            var result = await _roleManager.CreateAsync(newRole);

            if (result.Succeeded)
                return ApiServiceResult<Guid>.Success(newRole.Id,HttpStatusCode.Created);

            return ApiServiceResult<Guid>.Fail("Rol oluşurken hata meydana geldi",HttpStatusCode.BadRequest);
        }

        public async Task<ApiServiceResult> UpdateRoleAsync(string roleId,string newRoleName)
        {
            if (string.IsNullOrEmpty(newRoleName))
                return ApiServiceResult.Fail("Rol ismi boş geçilemez", HttpStatusCode.BadRequest);

            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
                return ApiServiceResult.Fail("Rol bulunamadi", HttpStatusCode.NotFound);

            role.Name = newRoleName;
            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
                return ApiServiceResult.Success(HttpStatusCode.NoContent);

            return ApiServiceResult.Fail("Rol güncellenirken hata meydana geldi", HttpStatusCode.BadRequest);
        }

        public async Task<ApiServiceResult> AssignRoleToUserAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return ApiServiceResult.Fail("Kullanici bulunamadi", HttpStatusCode.NotFound);

            if (string.IsNullOrEmpty(roleName))
                return ApiServiceResult.Fail("Rol ismi boş geçilemez", HttpStatusCode.BadRequest);

            var role = await _roleManager.FindByNameAsync(roleName);

            if (role == null)
                return ApiServiceResult.Fail("Rol bulunamadi", HttpStatusCode.NotFound);

            var result = await _userManager.AddToRoleAsync(user, roleName);

            if (result.Succeeded)
                return ApiServiceResult.Success(HttpStatusCode.NoContent);

            return ApiServiceResult.Fail("Rol atama esnasında hata meydana geldi", HttpStatusCode.BadRequest);
        }

        public async Task<ApiServiceResult> RemoveRoleFromUser(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return ApiServiceResult.Fail("Kullanici bulunamadi", HttpStatusCode.NotFound);

            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
                return ApiServiceResult.Fail("Rol bulunamadi", HttpStatusCode.NotFound);

            var result = await _userManager.RemoveFromRoleAsync(user, roleName);

            if (result.Succeeded)
                return ApiServiceResult.Success(HttpStatusCode.NoContent);

            return ApiServiceResult.Fail("Rol silme esnasında hata meydana geldi", HttpStatusCode.BadRequest);
        }

        public async Task<ApiServiceResult> DeleteRoleAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
                return ApiServiceResult.Fail("Rol bulunamadi", HttpStatusCode.NotFound);

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
                return ApiServiceResult.Success(HttpStatusCode.NoContent);

            return ApiServiceResult.Fail("Rol silinirken hata meydana geldi", HttpStatusCode.BadRequest);
        }

        public async Task<ApiServiceResult<List<AppRole>>> GetRolesAsync()
        {
            var roles =  await _roleManager.Roles.ToListAsync();
            return ApiServiceResult<List<AppRole>>.Success(roles, HttpStatusCode.OK);
        }
    }
}
