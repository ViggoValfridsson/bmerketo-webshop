﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bmerketo_webshop.Models.Entities;

public class ProductEntity
{
    [Key]
    public string ArticleId { get; set; } = null!;

    [Column(TypeName = "nvarchar(100)")]
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    [Column(TypeName = "money")]
    public decimal? OriginalPrice { get; set;}

    [Column(TypeName = "money")]
    public decimal CurrentPrice { get; set; }
    public int SalePercentage { get; set; }

    // 2048 because it is the de facto url lenght limit
    [Column(TypeName = "nvarchar(2048)")]
    public string ImageUrl { get; set; } = null!;
    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;
    public ICollection<ProductsTagsEntity> Tags { get; set; } = new HashSet<ProductsTagsEntity>();

    public static implicit operator ProductModel? (ProductEntity entity)
    {
        if (entity == null)
            return null;

        var model = new ProductModel
        {
            ArticleId = entity.ArticleId,
            Name = entity.Name,
            Description = entity.Description,
            OriginalPrice = entity.OriginalPrice,
            CurrentPrice = entity.CurrentPrice,
            SalePercentage = entity.SalePercentage,
            ImageUrl = entity.ImageUrl,
        };

        if (entity.Category != null)
            model.CategoryName = entity.Category.CategoryName;

        var tags = new List<string>();

        foreach (var productsTag in entity.Tags)
            tags.Add(productsTag.Tag.TagName);

        model.Tags = tags;

        return model;
    }
}
