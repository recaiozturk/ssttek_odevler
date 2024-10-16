﻿using LibraryManagementSystem.Service.Users.ViewModels;
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
                TempData["error"] = result.GetFirstError;
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            return View();
        }

    }
}
