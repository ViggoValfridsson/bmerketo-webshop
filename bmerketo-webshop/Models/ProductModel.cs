using bmerketo_webshop.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bmerketo_webshop.Models;

public class ProductModel
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public decimal? Price { get; set; }
    public string? ImageUrl { get; set; }
    public string CategoryName { get; set; } = null!;
    public ICollection<TagModel> Tags { get; set; } = new HashSet<TagModel>();

}
