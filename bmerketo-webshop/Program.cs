using bmerketo_webshop.Data;
using bmerketo_webshop.Helpers.Repositories;
using Microsoft.EntityFrameworkCore;

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
