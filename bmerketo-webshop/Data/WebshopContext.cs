using bmerketo_webshop.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace bmerketo_webshop.Data;

public class WebshopContext : IdentityDbContext<IdentityUser>
{
    public WebshopContext(DbContextOptions<WebshopContext> options) : base(options)
    {
    }

    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<ProductsTagsEntity> ProductsTags { get; set; }
    public DbSet<NewsletterSubscriberEntity> NewsletterSubscribers { get; set; }
}
