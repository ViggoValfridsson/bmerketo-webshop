using bmerketo_webshop.Models.Entities;
using bmerketo_webshop.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace bmerketo_webshop.Models.ViewModels;

public class SignUpViewModel
{
    [Required(ErrorMessage = "You must provide a first name.")]
    [MaxLength(100, ErrorMessage = "The maximum length is 100 characters.")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "You must provide a last name.")]
    [MaxLength(100, ErrorMessage = "The maximum length is 100 characters.")]
    public string LastName { get; set; } = null!;

    [MaxLength(100, ErrorMessage = "The maximum length is 100 characters.")]
    public string? CompanyName { get; set; }

    [Required(ErrorMessage = "You must enter a street name.")]
    [MaxLength(255, ErrorMessage = "The maximum length is 255 characters.")]
    public string StreetName { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a street name.")]
    [MaxLength(20, ErrorMessage = "The maximum length is 20 numbers.")]
    [RegularExpression(@"^[0-9]*$", ErrorMessage = "Please only enter numbers.")]
    public string PostalCode { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a city.")]
    [MaxLength(255, ErrorMessage = "The maximum length is 255 characters.")]
    public string City { get; set; } = null!;

    [Required(ErrorMessage = "You must provide an email address.")]
    [MinLength(6, ErrorMessage = "Invalid email. Enter a valid email and try again.")]
    [MaxLength(320, ErrorMessage = "Email is too long. Please enter less than 320 characters.")]
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email. Enter a valid email and try again.")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "You must provide a password.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must contain a minimum of eight characters, at least one uppercase letter, one lowercase letter, one number and and one special character.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;


    [Required(ErrorMessage = "You must confirm your password.")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; } = null!;

    public bool TermsAndConditions { get; set; }

    public static implicit operator AddressEntity(SignUpViewModel model)
    {
        if (model == null)
            return null!;

        return new AddressEntity
        {
            StreetName = model.StreetName,
            City = model.City,
            PostalCode = model.PostalCode,
        };
    }

    public static implicit operator AppUser(SignUpViewModel model)
    {
        if (model == null)
            return null!;

        return new AppUser
        {
            UserName = model.Email.ToLower(),
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email.ToLower(),
            CompanyName = model.CompanyName
        };
    }
}
