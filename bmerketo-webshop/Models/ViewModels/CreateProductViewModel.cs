using bmerketo_webshop.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bmerketo_webshop.Models.ViewModels;

public class CreateProductViewModel
{
    [Required(ErrorMessage = "You must provide an article number.")]
    [MaxLength(450, ErrorMessage = "Article number can not be more than 450 characters.")]
    public string ArticleNumber { get; set; } = null!;

    [Required(ErrorMessage = "You must provide a product name.")]
    [MaxLength(100, ErrorMessage = "Max length is 100 characters.")]
    public string Name { get; set; } = null!;
    
    [MaxLength(4000, ErrorMessage = "The max length is 4000 characters.")]
    public string? Description { get; set; }
    public decimal? OriginalPrice { get; set; }

    [Required(ErrorMessage = "You must enter the current price.")]
    public decimal CurrentPrice { get; set; }

    [Required(ErrorMessage = "You must enter the sale percentage.")]
    [RegularExpression(@"^[0-9]$|^[1-9][0-9]$|^(120)$", ErrorMessage = "Not a valid sale percentage. Please enter a number between 0-99")]
    public int SalePercentage { get; set; } = 0;

    [Required]
    public IFormFile Image { get; set; } = null!;

    [Required]
    public int CategoryId { get; set; }
    public List<int> TagIds { get; set; } = new List<int>();

    public static implicit operator ProductEntity (CreateProductViewModel viewModel)
    {
        if (viewModel == null)
            return null!;

        return new ProductEntity
        {
            ArticleId = viewModel.ArticleNumber,
            Name = viewModel.Name,
            Description = viewModel.Description,
            OriginalPrice = viewModel.OriginalPrice,
            CurrentPrice = viewModel.CurrentPrice,
            SalePercentage = viewModel.SalePercentage,
            CategoryId = viewModel.CategoryId,
            ImageUrl = $"/images/products/{viewModel.ArticleNumber}_{viewModel.Image.FileName}"
        };
    }
}
