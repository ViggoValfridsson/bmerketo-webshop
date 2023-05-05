using bmerketo_webshop.Helpers.Services;
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
        var result = await _productService.GetAsync(x => x.ArticleId == "abc1232");
        return View();
    }
}
