using bmerketo_webshop.Helpers.Repositories;
using bmerketo_webshop.Models.Entities;
using bmerketo_webshop.Models;
using System.Linq.Expressions;

namespace bmerketo_webshop.Helpers.Services;

public class CategoryService
{
    private readonly CategoryRepo _repo;

    public CategoryService(CategoryRepo repo)
    {
        _repo = repo;
    }

    // create


    //get
    public async Task<CategoryModel> GetAsync(Expression<Func<CategoryEntity, bool>> predicate)
    {
        var entity = await _repo.GetAsync(predicate);

        return entity!;
    }

    // get all
    public async Task<IEnumerable<CategoryModel>> GetAllAsync(Expression<Func<CategoryEntity, bool>> predicate = null!)
    {
        var products = new List<CategoryModel>();
        IEnumerable<CategoryEntity> entities;

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
