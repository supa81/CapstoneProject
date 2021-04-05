using BougieCandles.Data.Interfaces;
using BougieCandles.Data.Models;
using BougieCandles.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BougieCandles.Controllers
{
    public class CandleController : Controller
    {
        private readonly ICandleRepository _candleRepository;
        private readonly ICategoryRepository _categoryRepository;
        public CandleController(ICandleRepository candleRepository, ICategoryRepository categoryRepository)
        {
            _candleRepository = candleRepository;
            _categoryRepository = categoryRepository;
        }
        public ViewResult List(string category)
        {
            IEnumerable<Candle> candles;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                candles = _candleRepository.Candles.OrderBy(p => p.CandleId);
                currentCategory = "All candles";
            }
            else
            {
                candles = _candleRepository.Candles.Where(p => p.Category.CategoryName == category)
                   .OrderBy(p => p.CandleId);
                currentCategory = _categoryRepository.Categories.FirstOrDefault(c => c.CategoryName == category).CategoryName;
            }

            return View(new CandleListViewModel
            {
                Candles = candles,
                CurrentCategory = currentCategory
            });

        }
        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Candle> candles;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                candles = _candleRepository.Candles.OrderBy(p => p.CandleId);
            }
            else
            {
                candles = _candleRepository.Candles.Where(p => p.Name.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Candle/List.cshtml", new CandleListViewModel { Candles = candles, CurrentCategory = "All candles" }); ;
        }

        public ViewResult Details(int candleId)
        {
            var candle = _candleRepository.Candles.FirstOrDefault(d => d.CandleId == candleId);
            if (candle == null)
            {
                return View("~/Views/Candle/Details.cshtml");
            }
            return View(candle);
        }
    }
}

