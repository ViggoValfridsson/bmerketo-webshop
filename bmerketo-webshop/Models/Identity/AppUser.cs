using bmerketo_webshop.Models.Entities;
using bmerketo_webshop.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace bmerketo_webshop.Models.Identity;
public class AppUser : IdentityUser
{
    [Column(TypeName = "nvarchar(100)")]
    public string FirstName { get; set; } = null!;

    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; } = null!;

    [Column(TypeName = "nvarchar(100)")]
    public string? CompanyName { get; set; }
    public int AddressId { get; set; }
    public AddressEntity Address { get; set; } = null!;

    public static implicit operator UpdateUserViewModel (AppUser user)
    {
        if (user == null)
            return null!;

        return new UpdateUserViewModel
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            CompanyName = user.CompanyName,
            Email = user.UserName!
        };
    }
}
