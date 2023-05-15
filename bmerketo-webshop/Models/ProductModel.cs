using bmerketo_webshop.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bmerketo_webshop.Models;

public class ProductModel
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal? OriginalPrice { get; set; }
    public decimal CurrentPrice { get; set; }
    public int SalePercentage { get; set; }
    public string ImageUrl { get; set; } = null!;
    public string CategoryName { get; set; } = null!;
    public ICollection<string> Tags { get; set; } = new HashSet<string>();

}
