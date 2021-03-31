using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BougieCandles.Data.Models
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            AppDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<AppDbContext>();


            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Candles.Any())
            {
                context.AddRange
                (
                     new Candle
                     {
                         Name = "Candle 1",
                         Price = 7.95M,
                         Instock = true,
                         Stock = 10,
                         ShortDescription = "this is were the candle description will go",
                         IsPreferredItem = true,
                         ImageThumbNail = "https://www.google.com/aclk?sa=l&ai=DChcSEwiBhM2xxs3vAhUFH60GHUrLC94YABAGGgJwdg&sig=AOD64_2gyuTor8HrY3AfwQbd15Bdwon6Sw&adurl&ctype=5&ved=2ahUKEwjjrLyxxs3vAhVDZawKHYctA5IQwg96BAgBEFw"
                     },
                    new Candle
                    {
                        Name = "Candle 2",
                        Price = 7.95M,

                        ShortDescription = "this is were the candle description will go",
                        Instock = true,
                        Stock = 10,
                        IsPreferredItem = true,
                        ImageThumbNail = "https://www.google.com/aclk?sa=l&ai=DChcSEwiBhM2xxs3vAhUFH60GHUrLC94YABAMGgJwdg&sig=AOD64_1dlf8qFvncZKZ6dmyFCmif4xTaIA&adurl&ctype=5&ved=2ahUKEwjjrLyxxs3vAhVDZawKHYctA5IQvhd6BAgBEH8"
                    },
                    new Candle
                    {
                        Name = "Candle 3",
                        Price = 7.95M,
                        ShortDescription = "this is were the candle description will go",
                        Instock = true,
                        Stock = 10,
                        IsPreferredItem = true,
                        ImageThumbNail = "https://www.google.com/aclk?sa=l&ai=DChcSEwiBhM2xxs3vAhUFH60GHUrLC94YABAHGgJwdg&sig=AOD64_34YeSCDwe3T81P7uT9sw6Bl2h_Qg&adurl&ctype=5&ved=2ahUKEwjjrLyxxs3vAhVDZawKHYctA5IQvhd6BAgBEHg"
                    },
                   new Candle
                   {
                       Name = "Candle 4",
                       Price = 7.95M,
                       ShortDescription = "this is were the candle description will go",
                       Instock = true,
                       Stock = 10,
                       IsPreferredItem = true,
                       ImageThumbNail = "https://www.google.com/aclk?sa=l&ai=DChcSEwiBhM2xxs3vAhUFH60GHUrLC94YABAQGgJwdg&sig=AOD64_2PsGA5koqDoG4zo_3KsOzrtYXCgQ&adurl&ctype=5&ved=2ahUKEwjjrLyxxs3vAhVDZawKHYctA5IQvhd6BQgBEIkB"

                   }
               );
            }
            context.SaveChanges();
        }

        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Issa Vibe Mood Candles", Description = "All Candles For Every Mood " },
                        new Category { CategoryName = "Bougie Candles", Description = "Smell The Good Stuff" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }
    }
}
