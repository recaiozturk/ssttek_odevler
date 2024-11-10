using AutoMapper;
using LibraryManagementSystem.Repository.Users;
using LibraryManagementSystem.Service.Shared;
using LibraryManagementSystem.Service.Users.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Net;

namespace LibraryManagementSystem.Service.Users
{
    public class UserService(UserManager<AppUser> _userManager, IMapper _mapper) :IUserService
    {
        public async Task<ApiServiceResult<Guid>> CreateUserAsync(CreateUserRequest request)
        {
            var user = _mapper.Map<AppUser>(request);
            user.UserName = request.Email;

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var errorList = result.Errors.Select(x => x.Description).ToList();

                return ApiServiceResult<Guid>.Fail(errorList, HttpStatusCode.BadRequest);
            }

            return ApiServiceResult<Guid>.Success(user.Id, HttpStatusCode.Created);
        }

        public async Task<ApiServiceResult> UpdateUserAsync(UpdateUserRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (user == null)
                return ApiServiceResult.Fail("Kullanici bulunamadi", HttpStatusCode.NotFound);

            _mapper.Map(request, user);
            user.UserName = request.Email;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                var errorList = result.Errors.Select(x => x.Description).ToList();

                return ApiServiceResult.Fail(errorList, HttpStatusCode.BadRequest);
            }

            return ApiServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ApiServiceResult<UserResponse>> GetUserAsync(string userId)
        {

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return ApiServiceResult<UserResponse>.Fail("Kullanici bulunamadi", HttpStatusCode.NotFound);

            var userResponse=_mapper.Map<UserResponse>(user);

            return ApiServiceResult<UserResponse>.Success(userResponse,HttpStatusCode.OK);
        }

        public async Task<ApiServiceResult> DeleteUserAsync(string userId)
        {

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return ApiServiceResult<UserResponse>.Fail("Kullanici bulunamadi", HttpStatusCode.NotFound);


            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
                return ApiServiceResult.Success(HttpStatusCode.NoContent);

            return ApiServiceResult.Fail("Kulllanıcı silinirken hata meydana geldi", HttpStatusCode.BadRequest);
        }
    }
}
