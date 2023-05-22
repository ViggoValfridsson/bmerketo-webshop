using bmerketo_webshop.Helpers.Services;
using bmerketo_webshop.Models.Identity;
using bmerketo_webshop.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo_webshop.Controllers;

public class AccountController : Controller
{
    private readonly UserService _userService;
    private readonly SignInManager<AppUser> _signInManager;

    public AccountController(UserService userService, SignInManager<AppUser> signInManager)
    {
        _userService = userService;
        _signInManager = signInManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(SignInViewModel model)
    {
        if (ModelState.IsValid)
        {
             var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (result.Succeeded)
                return RedirectToAction("Index", "Home");
            else
                ModelState.AddModelError("", "Invalid credentials, please try again.");
        }

        return View(model);
    }

    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (await _userService.UserExists(x => x.Email == model.Email))
            {
                ModelState.AddModelError("", "An account with that email address already exists.");
                return View(model);
            }

            if (await _userService.SignUp(model))
                return RedirectToAction("SignIn");

            ModelState.AddModelError("", "Something went wrong, please try again.");
        }

        return View(model);
    }

    public async Task<IActionResult> LogOut()
    {
        if (_signInManager.IsSignedIn(User))
            await _signInManager.SignOutAsync();

        return LocalRedirect("/");
    }
}
