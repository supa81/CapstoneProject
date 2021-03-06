using BougieCandles.Data.Interfaces;
using BougieCandles.Models;
using BougieCandles.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BougieCandles.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICandleRepository _candleRepository;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ICandleRepository candleRepository, ILogger<HomeController> logger)
        {
            _logger = logger;
            _candleRepository = candleRepository;
        }
     
        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PreferredCandles = _candleRepository.PreferredCandles
            };
            return View(homeViewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

   
}

