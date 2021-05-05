using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BougieCandles.Data.Models
{
    public class Customer
    {
        [Key]
        [DisplayName("Member Id")]
        public int Id { get; set; }


        [DisplayName("Address")]
        public string Address { get; set; }


        [DisplayName("CategoryName")]
        public string Name { get; set; }


        [DisplayName("ZipCode")]
        public int ZipCode { get; set; }

        //[DisplayName("Balance")]
        //public double Balance { get; set; }

        //[ForeignKey("Candle")]
        //public int CandleId { get; set; }
        //public Candle Candle { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

    }
}
