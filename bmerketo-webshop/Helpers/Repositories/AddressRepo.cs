using bmerketo_webshop.Data;
using bmerketo_webshop.Models.Entities;

namespace bmerketo_webshop.Helpers.Repositories;

public class AddressRepo : GenericRepo<AddressEntity>
{
    public AddressRepo(WebshopContext context) : base(context)
    {
    }
}
