﻿using Microsoft.AspNetCore.Mvc;

namespace WebAppWithoutMvc.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
