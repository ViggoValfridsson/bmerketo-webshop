using System.ComponentModel.DataAnnotations.Schema;

namespace bmerketo_webshop.Models.Entities;

public class TagEntity
{
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string TagName { get; set; } = null!;
    public ICollection<ProductsTagsEntity> Products = new HashSet<ProductsTagsEntity>();

    public static implicit operator TagModel(TagEntity entity)
    {
        return new TagModel
        {
            Name = entity.TagName ?? ""
        };
    }
}
