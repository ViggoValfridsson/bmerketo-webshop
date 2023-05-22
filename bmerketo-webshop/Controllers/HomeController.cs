using bmerketo_webshop.Helpers.Repositories;
using bmerketo_webshop.Helpers.Services;
using bmerketo_webshop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace bmerketo_webshop.Controllers;

public class HomeController : Controller
{
    private readonly ProductService _productService;
    private readonly NewsletterSubscriperRepo _newsletterRepo;

    public HomeController(ProductService productService, NewsletterSubscriperRepo newsletterRepo)
    {
        _productService = productService;
        _newsletterRepo = newsletterRepo;
    }

    public IActionResult Index()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Index(NewsletterFormViewModel model)
    {
        ViewBag.ScrollToBottom = true;

        if (ModelState.IsValid)
        {
            try
            {
                if (await _newsletterRepo.GetAsync(x => x.Email == model.Email) == null)
                {
                    await _newsletterRepo.CreateAsync(model);
                    TempData["SuccessMessage"] = "Email added to newsletter list!";
                }
                else
                {
                    ModelState.AddModelError("", "Your email is already on the mailing list.");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong, please try again.");
            }
        }

        return View(model);
    }
}