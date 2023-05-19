using bmerketo_webshop.Helpers.Repositories;
using bmerketo_webshop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo_webshop.Controllers;

public class ContactController : Controller
{
    private readonly ContactFormRepo _contactFormRepo;

    public ContactController(ContactFormRepo contactFormRepo)
    {
        _contactFormRepo = contactFormRepo;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(ContactFormViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (await _contactFormRepo.CreateAsync(model) != null)
            {
                TempData["SuccessMessage"] = "Email added to newsletter list!";
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong when saving your information. Please try again");
            }
        }

        return View(model);
    }
}
