﻿using bmerketo_webshop.Data;
using bmerketo_webshop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace bmerketo_webshop.Helpers.Repositories;

public class ProductRepo : GenericRepo<ProductEntity>
{
    private readonly WebshopContext _context;

    public ProductRepo(WebshopContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ProductEntity?> GetAsync(Expression<Func<ProductEntity, bool>> predicate)
    {
        try
        {
            return await _context.Products.Include(x => x.Tags).ThenInclude(x => x.Tag).Include(x => x.Category).FirstOrDefaultAsync(predicate);
        }
        catch { return null!; }
    }

    public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        try
        {
            return await _context.Products.Include(x => x.Tags).ThenInclude(x => x.Tag).Include(x => x.Category).ToListAsync();
        }
        catch { return null!; }
    }

    public override async Task<IEnumerable<ProductEntity>> GetAllAsync(Expression<Func<ProductEntity, bool>> predicate)
    {
        try
        {
            return await _context.Products.Include(x => x.Tags).ThenInclude(x => x.Tag).Include(x => x.Category).Where(predicate).ToListAsync();
        }
        catch { return null!; }
    }
}
