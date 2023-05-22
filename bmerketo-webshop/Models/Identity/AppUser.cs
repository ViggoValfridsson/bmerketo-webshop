using bmerketo_webshop.Models.Entities;
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
}
