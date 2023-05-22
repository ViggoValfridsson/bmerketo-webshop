using bmerketo_webshop.Models.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace bmerketo_webshop.Models.Entities;

public class AddressEntity
{
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(255)")]
    public string StreetName { get; set; } = null!;
    
    [Column(TypeName = "nvarchar(20)")]
    public string PostalCode { get; set; } = null!;
    
    [Column(TypeName = "nvarchar(255)")]
    public string City { get; set; } = null!;
    public ICollection<AppUser> Users { get; set; } = new HashSet<AppUser>();
}
