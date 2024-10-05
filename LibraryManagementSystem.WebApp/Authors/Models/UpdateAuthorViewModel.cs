namespace LibraryManagementSystem.WebApp.Authors.Models
{
    public record UpdateAuthorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
    }
}
