using bmerketo_webshop.Data;
using bmerketo_webshop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace bmerketo_webshop.Helpers.Repositories;

public class TagRepo : GenericRepo<TagEntity>
{
    private readonly WebshopContext _context;

    public TagRepo(WebshopContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<TagEntity?> GetAsync(Expression<Func<TagEntity, bool>> predicate)
    {
        try
        {
            var entity = await _context.Tags.Include(x => x.Products).ThenInclude(x => x.Product).FirstOrDefaultAsync(predicate);
            return entity;
        }
        catch { return null; }
    }
}
