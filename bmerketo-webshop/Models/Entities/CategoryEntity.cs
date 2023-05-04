using System.ComponentModel.DataAnnotations.Schema;

namespace bmerketo_webshop.Models.Entities;

public class CategoryEntity
{
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string CategoryName { get; set; } = null!;
    public ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();
}