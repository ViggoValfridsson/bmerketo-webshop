﻿using Microsoft.AspNetCore.Mvc;

namespace bmerketo_webshop.Controllers;

public class DeniedController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
