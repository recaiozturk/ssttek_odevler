
namespace LibraryManagementSystem.Service.Users.DTOs
{
    public record UserResponse(Guid Id, string UserName, string Email, string? City);
}
