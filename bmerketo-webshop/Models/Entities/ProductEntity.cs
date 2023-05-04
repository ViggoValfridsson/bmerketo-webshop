using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bmerketo_webshop.Models.Entities;

public class ProductEntity
{
    [Key]
    public string ArticleId { get; set; } = null!;

    [Column(TypeName = "nvarchar(100)")]
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    [Column(TypeName = "money")]
    public decimal? Price { get; set;}

    // 2048 is the de facto url lenght limit
    [Column(TypeName = "nvarchar(2048)")]
    public string? ImageUrl { get; set; }
    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;
    public ICollection<ProductsTagsEntity> Tags { get; set; } = new HashSet<ProductsTagsEntity>();
}
