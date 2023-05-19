using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace bmerketo_webshop.Models.Entities;

public class ContactFormEntity
{
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public string FirstName { get; set; } = null!;
    
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; } = null!;
    
    [Column(TypeName = "nvarchar(320)")]
    public string Email { get; set; } = null!;

    [Column(TypeName = "nvarchar(15)")]
    public string PhoneNumber { get; set; } = null!;

    [Column(TypeName = "nvarchar(100)")]
    public string? CompanyName { get; set; }
    public string Content { get; set; } = null!;
}
