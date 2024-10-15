using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Repository.Users
{
    public class AppUser:IdentityUser<Guid>
    {
        public string? City { get; set; }
    }
}
