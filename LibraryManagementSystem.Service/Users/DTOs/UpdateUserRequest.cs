
namespace LibraryManagementSystem.Service.Users.DTOs
{
    public record UpdateUserRequest(Guid UserId, string Email, string? City);
}
