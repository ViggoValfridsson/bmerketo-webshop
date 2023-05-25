using bmerketo_webshop.Data;
using bmerketo_webshop.Helpers.Repositories;
using bmerketo_webshop.Models;
using bmerketo_webshop.Models.Entities;
using bmerketo_webshop.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
    public async Task<CreateProductViewModel?> CreateAsync(CreateProductViewModel viewModel)
    {
        throw new NotImplementedException();
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

    // needs to be removed
    public async Task<List<ProductModel>>? GetAllByTag(string tagName)
    {
        var tag = await _tagService.GetAsync(x => x.TagName == tagName);

        if (tag == null)
            return null!;

        var products = tag.Products.ToList();

        if (products.Count < 1)
            return null!;

        return products;
    }

    // get all
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


    // get all filtered

    //get all by tag kolla featured tag funktionen för hur man gör

    // update

    // delete
}
