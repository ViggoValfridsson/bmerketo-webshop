using bmerketo_webshop.Data;
using bmerketo_webshop.Helpers.Services;
using bmerketo_webshop.Models.Identity;
using bmerketo_webshop.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bmerketo_webshop.Controllers;

public class AccountController : Controller
{
    private readonly UserService _userService;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly WebshopContext _context;

    public AccountController(UserService userService, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, WebshopContext context)
    {
        _userService = userService;
        _signInManager = signInManager;
        _userManager = userManager;
        _context = context;
    }

    [Authorize]
    public async Task<IActionResult> Index()
    {
        var model = await _userService.GetAllInfoAsync(User.Identity!.Name!);

        if (model == null)
            return RedirectToAction("logout");

        return View(model);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Index(UpdateUserViewModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                if (!(await _signInManager.CheckPasswordSignInAsync((await _userManager.FindByEmailAsync(User.Identity!.Name!))!, model.OldPassword, false)).Succeeded)
                {
                    ModelState.AddModelError("", "Invalid password");
                    return View(model);
                }

                if (model.Email != User.Identity!.Name && await _userService.UserExists(x => x.Email == model.Email))
                {
                    ModelState.AddModelError("", "Email already in use");
                    return View(model);
                }

                var updatedUser = await _userService.UpdateAsync(model);

                if (updatedUser != null)
                {
                    // Log in here because otherwise user will be logged out after password/email change
                    if (!string.IsNullOrWhiteSpace(model.NewPassword))
                    {
                        await _signInManager.PasswordSignInAsync(model.Email, model.NewPassword, true, false);
                    }
                    else
                        await _signInManager.PasswordSignInAsync(model.Email, model.OldPassword, true, false);

                    TempData["SuccessMessage"] = "Changes saved";
                    return View(updatedUser);
                }

                ModelState.AddModelError("", "Something went wrong, please try again.");
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong, please try again.");
            }

        }

        return View(model);
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
