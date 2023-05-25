using bmerketo_webshop.Helpers.Repositories;
using bmerketo_webshop.Models.Entities;

namespace bmerketo_webshop.Helpers.Services;

public class ProductsTagsService
{
    private readonly ProductsTagsRepo _repo;

    public ProductsTagsService(ProductsTagsRepo repo)
    {
        _repo = repo;
    }

    public async Task<bool> CreateAsync(int tagId, string productId)
    {
        var productTag = new ProductsTagsEntity
        {
            TagId = tagId,
            ProductArticleNumber = productId,
        };

        var entity = await _repo.CreateAsync(productTag);

        if (entity == null)
        {
            return false;
        }

        return true;
    }
}
