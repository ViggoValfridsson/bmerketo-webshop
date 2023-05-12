using bmerketo_webshop.Data;
using bmerketo_webshop.Helpers.Repositories;
using bmerketo_webshop.Helpers.Services;
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

// Services
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<TagService>();
builder.Services.AddScoped<CategoryService>();

// Identity

var app = builder.Build();

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
