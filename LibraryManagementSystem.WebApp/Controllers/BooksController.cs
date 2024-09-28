
using AutoMapper;
using LibraryManagementSystem.WebApp.Models.ViewModels;
using LibraryManagementSystem.WebApp.Services;
using LibraryManagementSystem.WebApp.Util;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace LibraryManagementSystem.WebApp.Controllers
{
    public class BooksController(IBookService bookService,IMapper mapper) : Controller
    {
        [Route("kitaplar")]
        public IActionResult Index()
        {
            var books = bookService.GetAll();
            ViewBag.Title = "Kitaplar";
            ViewData["Offer"] = "Tüm Kitaplarda %20 İndirim Fırsatı";

            return View(books);
        }

        [Route("/kitap/{id:int}/{bookTitle}")]
        public IActionResult Detail(int id,string bookTitle)
        {
            var book = bookService.GetById(id);
            ViewBag.Title = book.Title;
            ViewData["Offer"] = "2 Kitap Alana 1 Kitap Bedava";

            return View(book);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookViewModel bookCreateModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            bookService.Add(bookCreateModel);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var book = bookService.GetById(id);

            return View(mapper.Map<UpdateBookViewModel>(book));
        }

        [HttpPost]
        public IActionResult Update(UpdateBookViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            bookService.Update(viewModel);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            bookService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
