using bmerketo_webshop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo_webshop.Controllers;

public class AccountController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult LogIn()
    {
        return View();
    }

    [HttpPost]
    public IActionResult LogIn(LogInViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            ModelState.AddModelError("", "Not implemented");
        }

        return View(viewModel);
    }

    public IActionResult SignUp()
    {
        return View();
    }
}
