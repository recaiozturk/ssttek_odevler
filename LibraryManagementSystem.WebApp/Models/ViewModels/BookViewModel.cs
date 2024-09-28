﻿namespace LibraryManagementSystem.WebApp.Models.ViewModels
{
    public record BookViewModel(
            int Id,
            string Title,
            string Author,
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
