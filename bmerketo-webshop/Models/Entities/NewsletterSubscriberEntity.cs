using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bmerketo_webshop.Models.Entities;

public class NewsletterSubscriberEntity
{
    [Key]
    [Column(TypeName = "nvarchar(320)")]
    public string Email { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
