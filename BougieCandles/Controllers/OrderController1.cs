﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BougieCandles.Controllers
{
    public class OrderController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}