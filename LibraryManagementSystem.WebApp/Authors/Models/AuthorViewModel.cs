using LibraryManagementSystem.WebApp.Books.Entities;

namespace LibraryManagementSystem.WebApp.Authors.Models
{
    public record AuthorViewModel(
            int Id,
            string Name,
            List<Book> Books

    );
}
