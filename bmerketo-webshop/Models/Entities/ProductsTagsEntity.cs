using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace bmerketo_webshop.Models.Entities;

[PrimaryKey(nameof(ProductArticleNumber), nameof(TagId))]
public class ProductsTagsEntity
{
    [ForeignKey("Product")]
    public string ProductArticleNumber { get; set; } = null!;
    public ProductEntity Product { get; set; } = null!;
    public int TagId { get; set; }
    public TagEntity Tag { get; set; } = null!;
}