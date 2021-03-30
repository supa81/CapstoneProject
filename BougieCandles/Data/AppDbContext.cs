using BougieCandles.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BougieCandles.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Producer", NormalizedName = "PRODUCER" });
        }

        public DbSet<ShoppingStoreEntities> ShoppingStoreEntities { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Candle> Candles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public IEnumerable Users { get; internal set; }
    }
}
