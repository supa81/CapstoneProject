using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BougieCandles.Data.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Candle Candle { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }

    }
}
