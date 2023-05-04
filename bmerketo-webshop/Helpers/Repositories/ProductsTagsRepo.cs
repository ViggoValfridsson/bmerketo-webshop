using bmerketo_webshop.Data;
using bmerketo_webshop.Models.Entities;

namespace bmerketo_webshop.Helpers.Repositories;

public class ProductsTagsRepo : GenericRepo<ProductsTagsEntity>
{
    public ProductsTagsRepo(WebshopContext context) : base(context)
    {
    }
}
