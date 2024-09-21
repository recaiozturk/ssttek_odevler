using LibraryManagementSystem.WebApp.Models;
using LibraryManagementSystem.WebApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.WebApp.Controllers
{
    public class BooksController(IBookRepository bookRepository) : Controller
    {
        [Route("kitaplar")]
        public IActionResult Index()
        {
            var books = bookRepository.GetAll();
            ViewBag.Title = "Kitaplar";
            ViewData["Offer"] = "Tüm Kitaplarda %20 İndirim Fırsatı";

            return View(books);
        }

        [Route("/kitap/{id:int}/{bookTitle}")]
        public IActionResult Detail(int id,string bookTitle)
        {
            var book = bookRepository.GetById(id);
            ViewBag.Title = book.Title;
            ViewData["Offer"] = "2 Kitap Alana 1 Kitap Bedava";

            return View(book);
        }
    }
}
