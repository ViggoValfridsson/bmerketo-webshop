using System.ComponentModel.DataAnnotations.Schema;

namespace bmerketo_webshop.Models.Entities;

public class TagEntity
{
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string TagName { get; set; } = null!;
    public ICollection<ProductsTagsEntity> Products { get; set; } = new HashSet<ProductsTagsEntity>();


    public static implicit operator TagModel?(TagEntity entity)
    {
        if (entity == null)
            return null;

        var tag = new TagModel
        {
            Id = entity.Id,
            Name = entity.TagName ?? ""
        };

        var productModels = new List<ProductModel>();

        foreach (var productTags in entity.Products)
        {
            productModels.Add(productTags.Product!);
        }

        tag.Products = productModels;

        return tag;
    }
}
