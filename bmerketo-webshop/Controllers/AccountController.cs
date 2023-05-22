using Microsoft.AspNetCore.Mvc;

namespace bmerketo_webshop.Controllers;

public class AccountController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
