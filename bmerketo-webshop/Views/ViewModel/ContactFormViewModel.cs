using System.ComponentModel.DataAnnotations;

namespace bmerketo_webshop.Views.ViewModel;

public class ContactFormViewModel
{
    [Required(ErrorMessage = "You must provide an email address.")]
    [MinLength(6, ErrorMessage = "Invalid email. Enter a valid email and try again.")]
    [MaxLength(320, ErrorMessage = "Email is too long. Please enter less than 320 characters.")]
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email. Enter a valid email and try again.")]
    public string Email { get; set; } = null!;
}
