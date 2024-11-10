using LibraryManagementSystem.Service.Roles;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Membership.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(IRoleService _roleService) : CustomControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            return CreateObjectResult(await _roleService.CreateRoleAsync(roleName));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateRole(string roleId,string roleName)
        {
            return CreateObjectResult(await _roleService.UpdateRoleAsync(roleId,roleName));
        }

        [HttpPost("AssignRoleToUser")]
        public async Task<IActionResult> AssignRoleToUser(string userId, string roleName)
        {
            return CreateObjectResult(await _roleService.AssignRoleToUserAsync(userId, roleName));
        }

        [HttpPost("RemoveRoleFromUser")]
        public async Task<IActionResult> RemoveRoleFromUser(string userId, string roleName)
        {
            return CreateObjectResult(await _roleService.RemoveRoleFromUser(userId, roleName));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            return CreateObjectResult(await _roleService.DeleteRoleAsync(roleId));
        }

        [HttpGet]
        public async Task<IActionResult> ListRolesAsync()
        {
            return CreateObjectResult(await _roleService.GetRolesAsync());
        }
    }
}
