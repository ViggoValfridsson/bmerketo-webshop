using System.ComponentModel.DataAnnotations.Schema;

namespace bmerketo_webshop.Models.Entities;

public class CategoryEntity
{
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string CategoryName { get; set; } = null!;
    public ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();

    public static implicit operator CategoryModel? (CategoryEntity entity)
    {
        if (entity == null)
            return null;

        var model = new CategoryModel
        {
            Name = entity.CategoryName
        };

        var productModels = new List<ProductModel>();

        if (entity.Products.Count > 1)
        {
            foreach (var product in entity.Products)
                productModels.Add(product!);
        }

        return model;
    }
}