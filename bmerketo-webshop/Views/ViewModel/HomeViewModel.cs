using System.ComponentModel.DataAnnotations;

namespace bmerketo_webshop.Views.ViewModel;

public class HomeViewModel
{
    [Required]
    [MinLength(6)]
    [MaxLength(320)]
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")]
    public string Email { get; set; } = null!;
}
