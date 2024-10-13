using LibraryManagementSystem.Repository.Authors;
using LibraryManagementSystem.Repository.Books;


namespace LibraryManagementSystem.Repository.Authors
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public List<Book>? Books { get; set; }
    }
}
