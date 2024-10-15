using LibraryManagementSystem.Service.Users.ViewModels;
using LibraryManagementSystem.Service.Users;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.WebApp.Controllers
{
    public class AuthController(IAuthService authService) : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
        {
            var result = await authService.SignUp(viewModel);

            if (result.AnyError)
            {
                TempData["error"] = result.GetFirstError;

                return View();
            }


            return RedirectToAction("Index", "Home");
        }

    }
}
