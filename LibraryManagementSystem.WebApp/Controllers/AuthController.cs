using LibraryManagementSystem.Service.Users;
using LibraryManagementSystem.Service.Users.ViewModels;
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
                TempData["Error"] = result.Errors;
                return View();
            }
            else
                return RedirectToAction("Index", "Home");
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel viewModel)
        {
            var result = await authService.SignIn(viewModel);

            if (result.AnyError)
            {
                TempData["Error"] = result.Errors;

                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            var result = await authService.SignOut();

            if (result.AnyError)
            {
                TempData["error"] = result.Errors;
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var currentUserName = User.Identity!.Name;
            
            var result=await authService.GetProfileInfo(currentUserName!);

            if (result.AnyError)
            {
                TempData["error"] = result.Errors;
            }

            return View(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> ProfileUpdate()
        {
            var result = await authService.GetProfileInfo(User.Identity!.Name!);

            if (result.AnyError)
                TempData["error"] = result.Errors;

            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> ProfileUpdate(UpdateProfileViewModel viewModel)
        {
            var result = await authService.UpdateProfile(viewModel, User.Identity!.Name!);

            if (result.AnyError)
                TempData["error"] = result.Errors;

            TempData["success"] = "Profiliniz başarı ile güncellendi";

            return RedirectToAction(nameof(Profile));
        }

        [HttpGet]
        public async Task<IActionResult> PasswordChange()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswordChange(ChangePasswordViewModel viewModel)
        {
            var result = await authService.ChangePassword(viewModel, User.Identity!.Name!);

            if (result.AnyError)
            {
                TempData["error"] = result.Errors;
                return View(viewModel);
            }
                
            TempData["success"] = "Şifreniz başarılı bir şekilde güncellendi";

            return RedirectToAction(nameof(Profile));
        }

    }
}
