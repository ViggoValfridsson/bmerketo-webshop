using System.ComponentModel.DataAnnotations;

namespace bmerketo_webshop.Models.ViewModels;

public class SignUpViewModel
{
    [Required(ErrorMessage = "You must provide an email address.")]
    [MinLength(6, ErrorMessage = "Invalid email. Enter a valid email and try again.")]
    [MaxLength(320, ErrorMessage = "Email is too long. Please enter less than 320 characters.")]
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email. Enter a valid email and try again.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "You must provide a password.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must contain a minimum of eight characters, at least one uppercase letter, one lowercase letter, one number and and one special character.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;


    [Required(ErrorMessage = "You must confirm your password.")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; } = null!;
}
