using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BougieCandles.ViewModels
{
    public class CandleViewModel
    {
        public int CandleId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public double Price { get; set; }
        public string ImageThumbnailUrl { get; set; }
    }
}
