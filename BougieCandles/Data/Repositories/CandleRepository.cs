using BougieCandles.Data.Interfaces;
using BougieCandles.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BougieCandles.Data.Repositories
{
    public class CandleRepository : ICandleRepository
    {
        private readonly AppDbContext _appDbContext;
        public CandleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
        //public IEnumerable<Item> Items => (IEnumerable<Item>)_appDbContext.ShoppingStoreEntities.Include(c => c.Categories);
        //public IEnumerable<Item> PreferredItems => (IEnumerable<Item>)_appDbContext.ShoppingStoreEntities.Where(p => p.Item.).Include(c => c.Categories);
        public IEnumerable<Candle> Candles => _appDbContext.Candles.Include(c => c.Category);

        public IEnumerable<Candle> PreferredCandles => _appDbContext.Candles.Where(p => p.IsPreferredCandle).Include(c => c.Category);

        public Candle GetCandleById(int candleId) => _appDbContext.Candles.FirstOrDefault(p => p.CandleId == candleId);



    }
}
