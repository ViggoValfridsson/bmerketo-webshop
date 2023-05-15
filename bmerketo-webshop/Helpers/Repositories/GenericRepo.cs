using bmerketo_webshop.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Data;

namespace bmerketo_webshop.Helpers.Repositories;

public abstract class GenericRepo<T> where T : class
{
    private readonly WebshopContext _context;

    protected GenericRepo(WebshopContext context)
    {
        _context = context;
    }

    public virtual async Task<T?> CreateAsync(T entity)
    {
        try
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        catch { return null;  }
    }

    public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
    {
        try
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }
        catch { return null; }
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(int page = 0, int pageAmount = 32)
    {
        try
        {
            return await _context.Set<T>().ToListAsync();
        }
        catch { return null!; }
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, int page = 0, int pageAmount = 32)
    {
        try
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
        catch { return null!; }
    }

    public virtual async Task<T?> UpdateAsync(T entity)
    {
        try
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        catch { return null; }
    }

    public virtual async Task<bool> DeleteAsync(T entity)
    {
        try
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }
        catch { return false; }
    }
}
