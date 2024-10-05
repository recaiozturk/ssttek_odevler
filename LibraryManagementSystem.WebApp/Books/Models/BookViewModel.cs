using LibraryManagementSystem.WebApp.Authors.Entities;

namespace LibraryManagementSystem.WebApp.Books.Models
{
    public record BookViewModel(
            int Id,
            int AuthorId,
            Author Author,
            string Title,
            int PublicationYear,
            string ISBN,
            string Genre,
            string Publisher,
            int PageCount,
            string Language,
            string Summary,
            int AvailableCopies,
            string? ImageUrl
    );
}
