using bmerketo_webshop.Helpers.Services;
using bmerketo_webshop.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
            return RedirectToAction("index", "notfound");

        var viewModel = new IndividualProductViewModel
        {
            Product = product,
            RelatedProducts = await _productService.GetAllAsync(x => x.Category.CategoryName == product.CategoryName && x.ArticleId != articleId, 0, 4)
        };

        return View(viewModel);
    }

    [Authorize(Roles = "admin")]
    [Route("product/add")]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    [Route("product/add")]
    public async Task<IActionResult> Add(CreateProductViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (await _productService.GetAsync(x => x.ArticleId == model.ArticleNumber) != null)
            {
                ModelState.AddModelError("", "Article number already in use. Change the article number and try again.");
                return View(model);
            }

            if (await _productService.CreateAsync(model))
            {
                return RedirectToAction("index", "admin");
            }

            ModelState.AddModelError("", "Something went wrong when creating the product, please try again.");
        }

        return View(model);
    }
}
