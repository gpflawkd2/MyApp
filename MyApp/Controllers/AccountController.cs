﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        public IActionResult Register()
        {
            return View();
        }
    }
}
