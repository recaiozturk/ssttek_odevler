
using AutoMapper;
using LibraryManagementSystem.WebApp.Books.Models;
using LibraryManagementSystem.WebApp.Books.Services;
using Microsoft.AspNetCore.Mvc;
namespace LibraryManagementSystem.WebApp.Controllers
{
    public class BooksController(IBookService bookService,IMapper mapper) : Controller
    {

        [Route("kitaplar/sayfa/{pageNumber:int}")]
        public IActionResult Index(int pageNumber=1, int pageSize=3)
        {
            var model = bookService.PrepareListPage(pageNumber, pageSize);
            ViewBag.Title = "Kitaplar";
            ViewData["Offer"] = "Tüm Kitaplarda %20 İndirim Fırsatı";

            return View(model);
        }

        [Route("/kitap/{id:int}/{bookTitle}")]
        public IActionResult Detail(int id,string bookTitle)
        {
            var book = bookService.GetById(id);
            ViewBag.Title = book.Title;
            ViewData["Offer"] = "2 Kitap Alana 1 Kitap Bedava";

            return View(book);
        }

        [Route("/kitap-ekle")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/kitap-ekle")]       
        public async Task<IActionResult> Create(CreateBookViewModel bookCreateModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            bookService.Add(bookCreateModel);
            return RedirectToAction("Index", new { pageNumber = 1 });
        }

        [Route("/kitap-guncelle/{id:int}/{bookTitle}")]
        public IActionResult Update(int id)
        {
            var book = bookService.GetById(id);

            return View(mapper.Map<UpdateBookViewModel>(book));
        }

        [HttpPost]
        [Route("/kitap-guncelle/{id:int}/{bookTitle}")]        
        public IActionResult Update(UpdateBookViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            bookService.Update(viewModel);

            return RedirectToAction("Index", new { pageNumber = 1 });
        }

        public IActionResult Delete(int id)
        {
            bookService.Delete(id);

            return RedirectToAction("Index", new { pageNumber = 1 });
        }
    }
}
