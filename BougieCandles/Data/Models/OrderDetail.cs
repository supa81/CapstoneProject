using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BougieCandles.Data.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int CandleId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public virtual Candle Candle { get; set; }
        public virtual Order Order { get; set; }
    }
}
