using BougieCandles.Data.Interfaces;
using BougieCandles.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BougieCandles.Data.Mocks
{

    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                     {
                         new Category { CategoryName = "Issa Vibe Moood Candles", Description = "All Candles for any mood" },
                         new Category { CategoryName = "All Candles", Description = "All Candles" }
                     };
            }
        }
    }

}
