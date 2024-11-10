namespace LibraryManagementSystem.Service.Users.DTOs
{
    public record CreateUserRequest(string Email, string Password, string? City);
}
