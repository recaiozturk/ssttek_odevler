namespace LibraryManagementSystem.Service.Users.ViewModels
{
    public class SignUpViewModel
    {
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? City { get; set; }
    }
}
