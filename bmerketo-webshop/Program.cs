using bmerketo_webshop.Data;
using bmerketo_webshop.Helpers.Repositories;
using bmerketo_webshop.Helpers.Seed;
using bmerketo_webshop.Helpers.Services;
using bmerketo_webshop.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Contexts
builder.Services.AddDbContext<WebshopContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("bmerketo_db")));

// Repositories
builder.Services.AddScoped<CategoryRepo>();
builder.Services.AddScoped<ProductRepo>();
builder.Services.AddScoped<TagRepo>();
builder.Services.AddScoped<ProductsTagsRepo>();
builder.Services.AddScoped<NewsletterSubscriperRepo>();
builder.Services.AddScoped<ContactFormRepo>();
builder.Services.AddScoped<AddressRepo>();

// Services
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<TagService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<UserService>();

// Identity
builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<WebshopContext>();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/account/signin";
    x.LogoutPath = "/";
    x.AccessDeniedPath = "/denied";
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<WebshopContext>();

    // Call SeedCategories method from Seed class and pass the dbContext
    var seed = new Seed(dbContext);
    await seed.SeedAll();
}

// Configure the HTTP request pipeline.
app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
