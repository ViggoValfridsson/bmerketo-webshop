using bmerketo_webshop.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace bmerketo_webshop.Models.ViewModels;

public class ContactFormViewModel
{
    [Required(ErrorMessage = "You must provide a first name.")]
    [MaxLength(100, ErrorMessage = "The maximum length is 100 characters.")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "You must provide a last name.")]
    [MaxLength(100, ErrorMessage = "The maximum length is 100 characters.")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "You must provide an email address.")]
    [MinLength(6, ErrorMessage = "Invalid email. Enter a valid email and try again.")]
    [MaxLength(320, ErrorMessage = "Email is too long. Please enter less than 320 characters.")]
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email. Enter a valid email and try again.")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "You must provide a phone number.")]
    [MaxLength(15, ErrorMessage = "Please enter less than 15 characters.")]
    [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$", ErrorMessage = "Not a valid phone number. Please try again")]
    public string PhoneNumber { get; set; } = null!;

    [MaxLength(100, ErrorMessage = "The maximum length is 100 characters.")]
    public string? CompanyName { get; set; }

    [Required(ErrorMessage = "You must enter a message.")]
    [MaxLength(4000, ErrorMessage = "Message is too long. Please try again with less than 4000 characters.")]
    public string Content { get; set; } = null!;

    public static implicit operator  ContactFormEntity (ContactFormViewModel model)
    {
        if (model == null)
            return null!;

        return new ContactFormEntity
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email.ToLower(),
            PhoneNumber = model.PhoneNumber,
            CompanyName = model.CompanyName,
            Content = model.Content,
        };
    }
}
