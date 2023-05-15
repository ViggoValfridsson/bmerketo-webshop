using bmerketo_webshop.Data;
using bmerketo_webshop.Models.Entities;

namespace bmerketo_webshop.Helpers.Repositories;

public class NewsletterSubscriperRepo : GenericRepo<NewsletterSubscriberEntity>
{
    public NewsletterSubscriperRepo(WebshopContext context) : base(context)
    {
    }
}
