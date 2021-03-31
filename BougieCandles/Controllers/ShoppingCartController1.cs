using BougieCandles.Data.Interfaces;
using BougieCandles.Data.Models;
using BougieCandles.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BougieCandles.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ICandleRepository _candleRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(ICandleRepository candleRepository, ShoppingCart shoppingCart)
        {
            _candleRepository = candleRepository;
            _shoppingCart = shoppingCart;
        }

        [Authorize]
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }

        [Authorize]
        public RedirectToActionResult AddToShoppingCart(int candleId)
        {
            var selectedDrink = _candleRepository.Candles.FirstOrDefault(p => p.CandleId == candleId);
            if (selectedDrink != null)
            {
                _shoppingCart.AddtoCart(selectedDrink, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int candleId)
        {
            var selectedCandle = _candleRepository.Candles.FirstOrDefault(p => p.CandleId == candleId);
            if (selectedCandle != null)
            {
                _shoppingCart.RemoveFromCart(selectedCandle);
            }
            return RedirectToAction("Index");
        }

    }
}
