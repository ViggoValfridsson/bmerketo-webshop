namespace bmerketo_webshop.Models.ViewModels;

public class IndividualProductViewModel
{
    public ProductModel Product { get; set; } = null!;
    public ICollection<ProductModel> RelatedProducts { get; set; } = new List<ProductModel>();
}
