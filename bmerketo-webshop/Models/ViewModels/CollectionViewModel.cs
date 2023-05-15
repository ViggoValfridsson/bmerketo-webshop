using bmerketo_webshop.Models.Entities;
using System.Linq.Expressions;

namespace bmerketo_webshop.Models.ViewModels;

public class CollectionViewmodel
{
    public string CollectionName { get; set; } = null!;

    // By default this will not perform any filtering
    public List<ProductModel> Products { get; set; } = new List<ProductModel>();
    public decimal AmountOfVisibleProducts { get; set; } = 8;

    // Set to zero in case it is not needed
    public decimal RowCount { get; set; } = 0;
    public decimal? Page { get; set;}
}
