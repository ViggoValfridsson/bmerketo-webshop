﻿using Microsoft.AspNetCore.Mvc;

namespace bmerketo_webshop.Controllers;

public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
