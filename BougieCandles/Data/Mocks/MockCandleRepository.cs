using BougieCandles.Data.Interfaces;
using BougieCandles.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BougieCandles.Data.Mocks
{
    public class MockCandleRepository : ICandleRepository
    {
    
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Candle> Candles
        {
            get
            {
                return new List<Candle>
                {
                    new Candle {
                        Name = "Candle 1",
                        Price = 7.95M,
                        Category = _categoryRepository.Categories.First(),
                        Instock = true,
                        Stock = 10,
                        ShortDescription = "this is were the candle description will go",
                        IsPreferredItem = true,
                        ImageThumbNail = "https://www.google.com/aclk?sa=l&ai=DChcSEwiBhM2xxs3vAhUFH60GHUrLC94YABAGGgJwdg&sig=AOD64_2gyuTor8HrY3AfwQbd15Bdwon6Sw&adurl&ctype=5&ved=2ahUKEwjjrLyxxs3vAhVDZawKHYctA5IQwg96BAgBEFw"
                    },
                    new Candle {
                        Name = "Candle 2",
                        Price = 7.95M,
                        Category = _categoryRepository.Categories.First(),
                        ShortDescription = "this is were the candle description will go",
                        Instock = true,
                        Stock = 10,
                        IsPreferredItem = true,
                        ImageThumbNail = "https://www.google.com/aclk?sa=l&ai=DChcSEwiBhM2xxs3vAhUFH60GHUrLC94YABAMGgJwdg&sig=AOD64_1dlf8qFvncZKZ6dmyFCmif4xTaIA&adurl&ctype=5&ved=2ahUKEwjjrLyxxs3vAhVDZawKHYctA5IQvhd6BAgBEH8"
                    },
                    new Candle {
                        Name = "Candle 3",
                        Price = 7.95M,
                        Category = _categoryRepository.Categories.First(),
                        ShortDescription = "this is were the candle description will go",
                        Instock = true,
                        Stock = 10,
                        IsPreferredItem = true,
                        ImageThumbNail = "https://www.google.com/aclk?sa=l&ai=DChcSEwiBhM2xxs3vAhUFH60GHUrLC94YABAHGgJwdg&sig=AOD64_34YeSCDwe3T81P7uT9sw6Bl2h_Qg&adurl&ctype=5&ved=2ahUKEwjjrLyxxs3vAhVDZawKHYctA5IQvhd6BAgBEHg"
                    },
                   new Candle {
                        Name = "Candle 4",
                        Price = 7.95M,
                        Category = _categoryRepository.Categories.First(),
                        ShortDescription = "this is were the candle description will go",
                        Instock = true,
                        Stock = 10,
                        IsPreferredItem = true,
                        ImageThumbNail = "https://www.google.com/aclk?sa=l&ai=DChcSEwiBhM2xxs3vAhUFH60GHUrLC94YABAQGgJwdg&sig=AOD64_2PsGA5koqDoG4zo_3KsOzrtYXCgQ&adurl&ctype=5&ved=2ahUKEwjjrLyxxs3vAhVDZawKHYctA5IQvhd6BQgBEIkB"

                   }
                };
            }
        }
        public IEnumerable<Candle> PreferredItems { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        // IEnumerable<Item> IItemRepository.Items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Candle GetCandleById(int CandleId)
        {
            throw new NotImplementedException();
        }

    }
}

