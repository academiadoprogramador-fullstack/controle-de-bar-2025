﻿using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
