using AutoMapper;
using LibraryManagementSystem.Service.Authors;
using LibraryManagementSystem.Service.Authors.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.WebApp.Controllers
{
    public class AuthorsController(IAuthorService authorService, IMapper mapper)  : Controller
    {
        [Route("yazarlar")]
        public async Task<IActionResult> Index()
        {
            var result =  await authorService.GetAllAsync();
            return View(result.Data);
        }

        [Route("/yazar/{id:int}/{authorTitle}")]
        public async Task<IActionResult> Detail(int id, string authorTitle)
        {
            var result = await authorService.GetByIdAsync(id);

            if (result.AnyError)
            {
                TempData["Error"] = result.Errors;
                return View();
            }

            return View(result.Data);
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

            var result = await authorService.AddAsync(authorkCreateModel);

            if (result.AnyError)
            {
                TempData["Error"] = result.Errors;
                return View();
            }

            return RedirectToAction("Index");
        }

        [Route("/yazar-guncelle/{id:int}/{authorTitle}")]
        public async Task<IActionResult> Update(int id)
        {
            var result = await authorService.GetByIdAsync(id);

            if (result.AnyError)
            {
                TempData["Error"] = result.Errors;
                return View();
            }

            return View(mapper.Map<UpdateAuthorViewModel>(result.Data));
        }

        [HttpPost]
        [Route("/yazar-guncelle/{id:int}/{authorTitle}")]
        public async Task<IActionResult> UpdateAsync(UpdateAuthorViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var result = await authorService.UpdateAsync(viewModel);

            if (result.AnyError)
            {
                TempData["Error"] = result.Errors;
                return View();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await authorService.GetByIdAsync(id);

            if (result.AnyError)
                TempData["Error"] = result.Errors;
            else
                await authorService.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
