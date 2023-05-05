﻿namespace bmerketo_webshop.Models;

public class CategoryModel
{
    public string Name { get; set; } = null!;
    public ICollection<ProductModel> Products { get; set; } = new HashSet<ProductModel>();
}
