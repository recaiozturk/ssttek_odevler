using LibraryManagementSystem.WebApp.Books.Entities;

namespace LibraryManagementSystem.WebApp.Authors.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public List<Book>? Books { get; set; }
    }
}
