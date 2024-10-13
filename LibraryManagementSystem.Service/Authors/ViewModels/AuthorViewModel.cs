
using LibraryManagementSystem.Repository.Books;

namespace LibraryManagementSystem.Service.Authors.ViewModels
{
    public record AuthorViewModel(
            int Id,
            string Name,
            List<Book> Books

    );
}
