﻿using Microsoft.AspNetCore.Mvc;

namespace bmerketo_webshop.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
