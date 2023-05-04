using bmerketo_webshop.Data;
using bmerketo_webshop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace bmerketo_webshop.Helpers.Repositories;

public class CategoryRepo : GenericRepo<CategoryEntity>
{
    private readonly WebshopContext _context;

    public CategoryRepo(WebshopContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<CategoryEntity?> GetAsync(Expression<Func<CategoryEntity, bool>> predicate)
    {
        try
        {
            return await _context.Categories.Include(x => x.Products).FirstOrDefaultAsync(predicate);
        }
        catch { return null; }
    }
}
