using BougieCandles.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BougieCandles.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Candle> PreferredCandles { get; set; }
    }
}
