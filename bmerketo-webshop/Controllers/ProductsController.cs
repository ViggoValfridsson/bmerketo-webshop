using bmerketo_webshop.Helpers.Repositories;
using bmerketo_webshop.Helpers.Services;
using bmerketo_webshop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo_webshop.Controllers;

public class ProductsController : Controller
{
    private readonly ProductService _productService;
    private readonly ProductRepo _productRepo;

    public ProductsController(ProductService productService, ProductRepo productRepo)
    {
        _productService = productService;
        _productRepo = productRepo;
    }

    [Route("products/{page?}")]
    public async Task<IActionResult> Index(int page = 1 )
    {
        var viewModel = new CollectionViewmodel
        {
            AmountOfVisibleProducts = 32,
            Products = await _productService.GetAllAsync(x => true, page - 1, 32),
            RowCount = await _productRepo.GetRowCountAsync(),
            Page = page
        };

        return View(viewModel);
    }

    [Route("products/category/{category}/{page?}")]
    public async Task<IActionResult> ProductsByCategory(string category, int page = 1)
    {
        var viewModel = new CollectionViewmodel
        {
            AmountOfVisibleProducts = 32,
            Products = await _productService.GetAllAsync(x => x.Category.CategoryName == category, page - 1, 32),
            RowCount = await _productRepo.GetRowCountAsync(x => x.Category.CategoryName == category),
            Page = page
        };

        return View("index", viewModel);
    }


    [Route("products/tags/{tag}/{page?}")]
    public async Task<IActionResult> ProductsByTag(string tag, int page = 1)
    {
        var viewModel = new CollectionViewmodel
        {
            AmountOfVisibleProducts = 32,
            Products = await _productService.GetAllAsync(x => x.Tags.Any(t => t.Tag.TagName == tag), page - 1, 32),
            RowCount = await _productRepo.GetRowCountAsync(x => x.Tags.Any(t => t.Tag.TagName == tag)),
            Page = page
        };

        return View("index", viewModel);
    }
}
