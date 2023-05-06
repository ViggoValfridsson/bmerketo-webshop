using bmerketo_webshop.Data;
using bmerketo_webshop.Helpers.Repositories;
using bmerketo_webshop.Models;
using bmerketo_webshop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Linq.Expressions;

namespace bmerketo_webshop.Helpers.Services;

public class ProductService
{
    private readonly ProductRepo _repo;
    private readonly TagService _tagService;

    public ProductService(ProductRepo repo, TagService tagService)
    {
        _repo = repo;
        _tagService = tagService;
    }

    // create


    //get
    public async Task<ProductModel?> GetAsync(Expression<Func<ProductEntity, bool>> predicate)
    {
        var entity = await _repo.GetAsync(predicate);

        return entity!;
    }

    // Gets random product with featured tag
    public async Task<ProductModel?> GetFeaturedAsync()
    {
        var tag = await _tagService.GetAsync(x => x.TagName == "Featured");

        if (tag == null)
            return null;

        var products = tag.Products.ToList();

        if (products.Count < 1)
            return null;

        var random = new Random();
        var randomNumber = random.Next(0, products.Count);

        return products[randomNumber];
    }

    // get all
    public async Task<List<ProductModel>> GetAllAsync(Expression<Func<ProductEntity, bool>> predicate = null!)
    {
        var products = new List<ProductModel>();
        IEnumerable<ProductEntity> entities;

        if (predicate == null)
            entities = await _repo.GetAllAsync();
        else
            entities = await _repo.GetAllAsync(predicate);

        foreach (var entity in entities)
            products.Add(entity!);

        return products;
    }


    // get all filtered

    //get all by tag kolla featured tag funktionen för hur man gör

    // update

    // delete
}
