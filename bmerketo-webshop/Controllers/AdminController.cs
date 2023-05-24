using bmerketo_webshop.Helpers.Services;
using bmerketo_webshop.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo_webshop.Controllers;

[Authorize(Roles = "admin")]
public class AdminController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public AdminController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Route("admin/user/{userId}")]
    public new async Task<IActionResult> User(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            return RedirectToAction("index", "notfound");

        return View(user);
    }

    [HttpPost]
    [Route("admin/user/{userId}")]
    public new async Task<IActionResult> User(string userId, string[] selectedRoles)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            return RedirectToAction("index", "notfound");

        var userCurrentRoles = await _userManager.GetRolesAsync(user);
        var rolesToRemove = userCurrentRoles.Except(selectedRoles);

        var removeResult = await _userManager.RemoveFromRolesAsync(user, rolesToRemove);

        if (!removeResult.Succeeded)
        {
            TempData["FailureMessage"] = "Something went wrong, please try again";
            return View(user);
        }

        var rolesToAdd = selectedRoles.Except(userCurrentRoles);
        var addResult = await _userManager.AddToRolesAsync(user, rolesToAdd);

        if(!addResult.Succeeded) 
        {
            TempData["FailureMessage"] = "Roles were successfully removed but something went wrong when adding the roles. Please try again.";
            return View(user);
        }

        TempData["SuccessMessage"] = "Changes saved";
        return View(user);
    }
}
