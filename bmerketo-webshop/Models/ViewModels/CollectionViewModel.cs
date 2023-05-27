namespace bmerketo_webshop.Models.ViewModels;

public class CollectionViewmodel
{
    public string CollectionName { get; set; } = null!;
    public List<ProductModel> Products { get; set; } = new List<ProductModel>();
    public decimal AmountOfVisibleProducts { get; set; } = 8;
    public int RowCount { get; set; }
    public int Page { get; set; } 
}
