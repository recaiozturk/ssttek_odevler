using LibraryManagementSystem.Repository.Books;
using LibraryManagementSystem.Service.Books.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LibraryManagementSystem.WebApp.Filters
{
    public class BookDetailResultFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ViewResult viewResult)
            {
                if (viewResult.Model is BookViewModel book)
                {
                    if (book.AvailableCopies < 6)
                    {
                        viewResult.ViewData["BannerMessage"] = $"Sınırlı Sayı(Son {book.AvailableCopies} adet)";
                    }
                }
            }
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {

        }
    }
}
