using bmerketo_webshop.Migrations;
using bmerketo_webshop.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace bmerketo_webshop.Models.ViewModels;

public class NewsletterFormViewModel
{
    [Required(ErrorMessage = "You must provide an email address.")]
    [MinLength(6, ErrorMessage = "Invalid email. Enter a valid email and try again.")]
    [MaxLength(320, ErrorMessage = "Email is too long. Please enter less than 320 characters.")]
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email. Enter a valid email and try again.")]
    public string Email { get; set; } = null!;

    public static implicit operator NewsletterSubscriberEntity(NewsletterFormViewModel model)
    {
        if (model == null)
            return null!;

        return new NewsletterSubscriberEntity
        {
            Email = model.Email
        };
    }
}
