using BougieCandles.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BougieCandles.Data
{
    //public class AppDbContext : IdentityDbContext<IdentityUser>
    //{
    //    //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    //    //{
    //    //}

    //    //public DbSet<Candle> Candles { get; set; }
    //    //public DbSet<Category> Categories { get; set; }
    //    //public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    //    //public DbSet<Order> Orders { get; set; }
    //    //public DbSet<OrderDetail> OrderDetails { get; set; }
    //}
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
             : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Users", NormalizedName = "USERS" });
        }


        //public DbSet<ShoppingStoreEntities> ShoppingStoreEntities { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Candle> Candles { get; set; }
        public DbSet<Category> Categories { get; set; }
        // public DbSet<Producer> Producers { get; set; }
        public IEnumerable Users { get; internal set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<BougieCandles.Data.Models.Customer> Customer { get; set; }
    }
}
