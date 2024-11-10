using LibraryManagementSystem.Service.Users;
using LibraryManagementSystem.Service.Users.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Membership.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService _userService) : CustomControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserRequest request)
        {
            return CreateObjectResult(await _userService.CreateUserAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserRequest request)
        {
            return CreateObjectResult(await _userService.UpdateUserAsync(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(string userId)
        {
            return CreateObjectResult(await _userService.GetUserAsync(userId));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            return CreateObjectResult(await _userService.DeleteUserAsync(userId));
        }
    }
}
