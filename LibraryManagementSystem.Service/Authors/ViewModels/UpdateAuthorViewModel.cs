namespace LibraryManagementSystem.Service.Authors.ViewModels
{
    public record UpdateAuthorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
    }
}
