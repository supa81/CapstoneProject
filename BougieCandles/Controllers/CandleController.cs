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
    }
}

