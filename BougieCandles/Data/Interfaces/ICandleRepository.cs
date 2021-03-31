using BougieCandles.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BougieCandles.Data.Interfaces
{
    public interface ICandleRepository
    {
        IEnumerable<Candle> Candles { get; }
        IEnumerable<Candle> PreferredCandles { get; }

        Candle GetCandleById(int candleId);

    }
}
