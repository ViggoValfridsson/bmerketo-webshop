using bmerketo_webshop.Models.Entities;
using bmerketo_webshop.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace bmerketo_webshop.Data;

public class WebshopContext : IdentityDbContext<AppUser>
{
    public WebshopContext(DbContextOptions<WebshopContext> options) : base(options)
    {
    }

    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<ProductsTagsEntity> ProductsTags { get; set; }
    public DbSet<NewsletterSubscriberEntity> NewsletterSubscribers { get; set; }
    public DbSet<ContactFormEntity> ContactForms { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }
}
