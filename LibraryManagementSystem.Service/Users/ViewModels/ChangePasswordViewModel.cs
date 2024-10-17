namespace LibraryManagementSystem.Service.Users.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string OldPassword { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string RePassword { get; set; } = default!;
    }
}
