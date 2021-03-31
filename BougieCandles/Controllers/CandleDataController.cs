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
    [Route("api/[controller]")]
    public class CandleDataController : Controller
    {
        private readonly ICandleRepository _candleRepository;

        public CandleDataController(ICandleRepository candleRepository)
        {
            _candleRepository = candleRepository;
        }

        [HttpGet]
        public IEnumerable<CandleViewModel> LoadMoreCandles()
        {
            IEnumerable<Candle> dbCandles = null;

            dbCandles = _candleRepository.Candles.OrderBy(p => p.CandleId).Take(10);

            List<CandleViewModel> candles = new List<CandleViewModel>();

            foreach (var dbCandle in dbCandles)
            {
                candles.Add(MapDbCandleToCandleViewModel(dbCandle));
            }
            return candles;
        }

        private CandleViewModel MapDbCandleToCandleViewModel(Candle dbCandle) => new CandleViewModel()
        {
            CandleId = dbCandle.CandleId,
            Name = dbCandle.Name,
            Price = dbCandle.Price,
            ShortDescription = dbCandle.ShortDescription,
            ImageThumbnailUrl = dbCandle.ImageThumbNail
        };

    }
}
