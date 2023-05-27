namespace bmerketo_webshop.Models;

public class ProductModel
{
    public string ArticleId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal? OriginalPrice { get; set; }
    public decimal CurrentPrice { get; set; }
    public int SalePercentage { get; set; }
    public string ImageUrl { get; set; } = null!;
    public string CategoryName { get; set; } = null!;
    public List<string> Tags { get; set; } = new List<string>();

}
