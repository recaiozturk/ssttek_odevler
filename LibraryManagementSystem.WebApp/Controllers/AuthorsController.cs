using AutoMapper;
using LibraryManagementSystem.WebApp.Authors.Models;
using LibraryManagementSystem.WebApp.Authors.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.WebApp.Controllers
{
    public class AuthorsController(IAuthorService authorService, IMapper mapper)  : Controller
    {
        [Route("yazarlar")]
        public async Task<IActionResult> Index()
        {
            var model =  await authorService.GetAllAsync();
            return View(model);
        }

        [Route("/yazar/{id:int}/{authorTitle}")]
        public async Task<IActionResult> Detail(int id, string authorTitle)
        {
            //var author = await authorService.GetByIdAsync(id);
            var author = await authorService.GetAuthorWithBooksAsync(id);
            return View(author);
        }

        [Route("/yazar-ekle")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/yazar-ekle")]
        public async Task<IActionResult> Create(CreateAuthorViewModel authorkCreateModel)
        {
            if (!ModelState.IsValid)
                return View(authorkCreateModel);

            await authorService.AddAsync(authorkCreateModel);
            return RedirectToAction("Index");
        }

        [Route("/yazar-guncelle/{id:int}/{authorTitle}")]
        public async Task<IActionResult> Update(int id)
        {
            var book = await authorService.GetByIdAsync(id);

            return View(mapper.Map<UpdateAuthorViewModel>(book));
        }

        [HttpPost]
        [Route("/yazar-guncelle/{id:int}/{authorTitle}")]
        public IActionResult Update(UpdateAuthorViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            authorService.UpdateAsync(viewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await authorService.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
