using bmerketo_webshop.Data;
using bmerketo_webshop.Helpers.Repositories;
using bmerketo_webshop.Models;
using bmerketo_webshop.Models.Entities;
using bmerketo_webshop.Models.ViewModels;
using System.Linq.Expressions;

namespace bmerketo_webshop.Helpers.Services;

public class ProductService
{
    private readonly ProductRepo _repo;
    private readonly TagService _tagService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly ProductsTagsService _productsTagsService;

    public ProductService(ProductRepo repo, TagService tagService, IWebHostEnvironment webHostEnvironment, ProductsTagsService productsTagsService)
    {
        _repo = repo;
        _tagService = tagService;
        _webHostEnvironment = webHostEnvironment;
        _productsTagsService = productsTagsService;
    }

    public async Task<bool> CreateAsync(CreateProductViewModel viewModel)
    {
        if (!await UploadImageAsync(viewModel))
            return false;

        var productEntity = await _repo.CreateAsync(viewModel);

        if (productEntity == null)
            return false;

        foreach (var tagId in viewModel.TagIds)
        {
            var productTagWasCreated = await _productsTagsService.CreateAsync(tagId, viewModel.ArticleNumber);
            
            if (!productTagWasCreated)
                return false;
        }

        return true;
    }

    public async Task<bool> UploadImageAsync(CreateProductViewModel viewModel)
    {
        try
        {
            string imagePath = $"{_webHostEnvironment.WebRootPath}/images/products/{viewModel.ArticleNumber}_{viewModel.Image.FileName}";
            await viewModel.Image.CopyToAsync(new FileStream(imagePath, FileMode.Create));

            return true;
        }
        catch { return false; }
    }

    public async Task<ProductModel?> GetAsync(Expression<Func<ProductEntity, bool>> predicate)
    {
        var entity = await _repo.GetAsync(predicate);

        return entity!;
    }

    // need refactoring
    public async Task<ProductModel?> GetRandomByTagAsync(string tagName)
    {
        var tag = await _tagService.GetAsync(x => x.TagName == tagName);

        if (tag == null)
            return null;

        var products = tag.Products.ToList();

        if (products.Count < 1)
            return null;

        var random = new Random();
        var randomNumber = random.Next(0, products.Count);

        return products[randomNumber];
    }

    public async Task<List<ProductModel>> GetAllAsync(Expression<Func<ProductEntity, bool>> predicate = null!, int page = 0, int pageAmount = 32)
    {
        var products = new List<ProductModel>();
        IEnumerable<ProductEntity> entities;

        if (predicate == null)
            entities = await _repo.GetAllAsync();
        else
            entities = await _repo.GetAllAsync(predicate, page, pageAmount);

        if (entities == null)
            return null!;

        foreach (var entity in entities)
            products.Add(entity!);

        return products;
    }
}
