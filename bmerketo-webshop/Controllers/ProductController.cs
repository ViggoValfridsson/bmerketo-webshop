using bmerketo_webshop.Helpers.Services;
using bmerketo_webshop.Models.ViewModels;
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

        var viewModel = new IndividualProductViewModel
        {
            Product = product,
            RelatedProducts = await _productService.GetAllAsync(x => x.Category.CategoryName == product.CategoryName && x.ArticleId != articleId, 0, 4)
        };

        return View(viewModel);
    }
}
