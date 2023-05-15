using bmerketo_webshop.Models.Entities;
using System.Linq.Expressions;

namespace bmerketo_webshop.Models.ViewModels;

public class CollectionViewmodel
{
    public string CollectionName { get; set; } = null!;

    // By default this will not perform any filtering
    public Expression<Func<ProductEntity, bool>> Filter { get; set; } = null!;
    public decimal ProductAmount { get; set; } = 8;
}
