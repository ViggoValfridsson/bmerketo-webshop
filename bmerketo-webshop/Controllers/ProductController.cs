using bmerketo_webshop.Helpers.Services;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo_webshop.Controllers;

public class ProductController : Controller
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [Route("product/{articleId}")]
    public async Task<IActionResult> Index(string articleId)
    {
        var product = await _productService.GetAsync(x => x.ArticleId == articleId);

        if (product == null)
            return NotFound();

        return View(product);
    }
}
