using bmerketo_webshop.Data;
using bmerketo_webshop.Helpers.Repositories;
using bmerketo_webshop.Models;
using bmerketo_webshop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace bmerketo_webshop.Helpers.Services;

public class ProductService
{
    private readonly ProductRepo _repo;

    public ProductService(ProductRepo repo)
    {
        _repo = repo;
    }
    // create

    // get
    public async Task<ProductModel?> GetAsync(Expression<Func<ProductEntity, bool>> predicate)
    {
        var entity = await _repo.GetAsync(predicate);

        return entity;
    }

    // get all

    // get all filtered

    // update

    // delete
}
