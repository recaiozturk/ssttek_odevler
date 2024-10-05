
using AutoMapper;
using LibraryManagementSystem.WebApp.Authors.Services;
using LibraryManagementSystem.WebApp.Books.Models;
using LibraryManagementSystem.WebApp.Books.Services;
using LibraryManagementSystem.WebApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
namespace LibraryManagementSystem.WebApp.Controllers
{
    public class BooksController(IBookService bookService,IAuthorService authorService,IMapper mapper) : Controller
    {

        [Route("kitaplar/sayfa/{pageNumber:int}")]
        public async Task<IActionResult> Index(int pageNumber=1, int pageSize=3)
        {
            var model = await bookService.PrepareListPageAsync(pageNumber, pageSize);
            return View(model);
        }

        [Route("/kitap/{id:int}/{bookTitle}")]
        public async Task<IActionResult> Detail(int id,string bookTitle)
        {
            var book = await bookService.GetBookWithAuthorAsync(id);
            return View(book);
        }

        [Route("/kitap-ekle")]
        public async Task<IActionResult> Create()
        {
            var authorsSelectList=await authorService.GetAuthorsSelectListAsync();
            ViewBag.Authors = authorsSelectList;

            return View();
        }

        [HttpPost]
        [Route("/kitap-ekle")]       
        public async Task<IActionResult> Create(CreateBookViewModel bookCreateModel)
        {
            if (!ModelState.IsValid)
            {
                var authorsSelectList = await authorService.GetAuthorsSelectListAsync();
                ViewBag.Authors = authorsSelectList;
                return View(bookCreateModel);
            }
                

            await bookService.AddAsync(bookCreateModel);
            return RedirectToAction("Index", new { pageNumber = 1 });
        }

        [Route("/kitap-guncelle/{id:int}/{bookTitle}")]
        public async Task<IActionResult> Update(int id)
        {
            var book = await bookService.GetByIdAsync(id);
            var authorsSelectList = await authorService.GetAuthorsSelectListAsync();
            ViewBag.Authors = authorsSelectList;

            return View(mapper.Map<UpdateBookViewModel>(book));
        }

        [HttpPost]
        [Route("/kitap-guncelle/{id:int}/{bookTitle}")]        
        public async Task<IActionResult> Update(UpdateBookViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var authorsSelectList = await authorService.GetAuthorsSelectListAsync();
                ViewBag.Authors = authorsSelectList;
                return View(viewModel);
            }
                
            await bookService.UpdateAsync(viewModel);

            return RedirectToAction("Index", new { pageNumber = 1 });
        }

        [Route("/kitap-ara")]
        public async Task<IActionResult> Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> SearchBooks(string searchValue)
        {
            var searchedBooksAsJson = await bookService.GetSearchedBooksAsync(searchValue);

            return Json(searchedBooksAsJson);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await bookService.DeleteAsync(id);

            return RedirectToAction("Index", new { pageNumber = 1 });
        }
    }
}
