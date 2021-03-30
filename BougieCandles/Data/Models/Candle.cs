using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BougieCandles.Data.Models
{
    public class Candle
    {
        [Key]
        public int CandleId { get; set; }
        public int CategoryId { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string ShortDescription { get; set; }

        public string ImageThumbNail { get; set; }
        public bool Instock { get; set; }
        public int Stock { get; set; }

        public bool IsPreferredItem { get; set; }
        public Category Category { get; set; }
        public Producer Producer { get; set; }

    }
}
