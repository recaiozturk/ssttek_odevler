﻿
using AutoMapper;
using LibraryManagementSystem.Service.Authors;
using LibraryManagementSystem.Service.Books;
using LibraryManagementSystem.Service.Books.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace LibraryManagementSystem.WebApp.Controllers
{
    public class BooksController(IBookService bookService,IAuthorService authorService,IMapper mapper) : Controller
    {

        [Route("kitaplar/sayfa/{pageNumber:int}")]
        public async Task<IActionResult> Index(int pageNumber=1, int pageSize=3)
        {
            var result  = await bookService.PrepareListPageAsync(pageNumber, pageSize);
            return View(result.Data);
        }

        [Route("/kitap/{id:int}/{bookTitle}")]
        public async Task<IActionResult> Detail(int id,string bookTitle)
        {
            var result = await bookService.GetBookWithAuthorAsync(id);

            if (result.AnyError)
            {
                TempData["Error"] = result.Errors;
                return View();
            }

            return View(result.Data);
        }

        [Route("/kitap-ekle")]
        public async Task<IActionResult> Create()
        {
            var authorsSelectList=await authorService.GetAuthorsSelectListAsync();
            ViewBag.Authors = authorsSelectList.Data;

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
            
            var result=await bookService.AddAsync(bookCreateModel);

            if (result.AnyError)
            {
                TempData["Error"] = result.Errors;
                return View();
            }

            return RedirectToAction("Index", new { pageNumber = 1 });
        }

        [Route("/kitap-guncelle/{id:int}/{bookTitle}")]
        public async Task<IActionResult> Update(int id)
        {
            var authorsSelectListResult = await authorService.GetAuthorsSelectListAsync();
            ViewBag.Authors = authorsSelectListResult.Data;

            var bookResult = await bookService.GetByIdAsync(id);

            if (bookResult.AnyError)
            {
                TempData["Error"] = bookResult.Errors;
                return View();
            }
            return View(mapper.Map<UpdateBookViewModel>(bookResult.Data));
        }

        [HttpPost]
        [Route("/kitap-guncelle/{id:int}/{bookTitle}")]        
        public async Task<IActionResult> Update(UpdateBookViewModel viewModel)
        {
            var authorsSelectListResult = await authorService.GetAuthorsSelectListAsync();
            ViewBag.Authors = authorsSelectListResult.Data;

            if (!ModelState.IsValid)
                return View(viewModel);

            var result =await bookService.UpdateAsync(viewModel);

            if (result.AnyError)
            {
                TempData["Error"] = result.Errors;
                return View(viewModel);
            }
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
            var searchedBooksAsJsonResult = await bookService.GetSearchedBooksAsync(searchValue);

            return Json(searchedBooksAsJsonResult.Data);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await bookService.DeleteAsync(id);

            if (result.AnyError)
            {
                TempData["Error"] = result.Errors;
                return RedirectToAction("Index", new { pageNumber = 1 });
            }

            return RedirectToAction("Index", new { pageNumber = 1 });
        }
    }
}
