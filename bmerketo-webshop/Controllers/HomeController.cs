using bmerketo_webshop.Helpers.Services;
using bmerketo_webshop.Views.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo_webshop.Controllers;

public class HomeController : Controller
{
    private readonly ProductService _productService;

    public HomeController(ProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Index(ContactFormViewModel model)
    {
        if (ModelState.IsValid)
        {

        }

        return View();
    }
}