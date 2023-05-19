namespace bmerketo_webshop.Models.ViewModels;

public class ReviewViewModel
{
    public float Stars { get; set; }
    public string UserName { get; set; } = "Anonymous";
    public string ReviewBody { get; set; } = null!;
}
