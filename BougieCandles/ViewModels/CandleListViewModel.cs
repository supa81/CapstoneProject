using BougieCandles.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BougieCandles.ViewModels
{
    public class CandleListViewModel
    {
        public IEnumerable<Candle> Candles { get; set; }

        public string CurrentCategory { get; set; }
    }
}
