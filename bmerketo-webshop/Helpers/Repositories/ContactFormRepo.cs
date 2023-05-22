using bmerketo_webshop.Data;
using bmerketo_webshop.Models.Entities;

namespace bmerketo_webshop.Helpers.Repositories;

public class ContactFormRepo : GenericRepo<ContactFormEntity>
{
    public ContactFormRepo(WebshopContext context) : base(context)
    {
    }
}
