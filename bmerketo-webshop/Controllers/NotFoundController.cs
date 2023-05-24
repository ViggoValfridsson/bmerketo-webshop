using Microsoft.AspNetCore.Mvc;

namespace bmerketo_webshop.Controllers;

public class NotFoundController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
