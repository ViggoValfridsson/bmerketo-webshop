using System.ComponentModel.DataAnnotations;

namespace bmerketo_webshop.Models.ViewModels;

public class SignInViewModel
{
    [Required(ErrorMessage = "You need to enter an email.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "You need to enter a password.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required]
    public bool RememberMe { get; set; } = false;
}
