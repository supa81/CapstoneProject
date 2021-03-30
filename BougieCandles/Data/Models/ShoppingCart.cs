using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BougieCandles.Data.Models
{
    public class ShoppingCart
    {private readonly ApplicationDbContext DbContext;
        private ShoppingCart(ApplicationDbContext appDbContext)
        {
            DbContext = appDbContext;
        }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<HttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };

        }
        public void AddtoCart(Item item, int amount)
        {
            var shoppingcartItem = DbContext.ShoppingCartItems.SingleOrDefault(s => s.Item.ItemId == item.ItemId && s.ShoppingCartId == ShoppingCartId);
            if (shoppingcartItem == null)
            {
                shoppingcartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Item = item,
                    Amount = 1
                };
                DbContext.ShoppingCartItems.Add(shoppingcartItem);
            }
            else
            {
                shoppingcartItem.Amount++;
            }
            DbContext.SaveChanges();

        }
        public int RemoveFromCart(Item item)
        {
            var shoppingcartItem = DbContext.ShoppingCartItems.SingleOrDefault(s => s.Item.ItemId == item.ItemId && s.ShoppingCartId == ShoppingCartId);
            var localAmount = 0;
            if (shoppingcartItem != null)
            {
                if (shoppingcartItem.Amount > 1)
                {
                    shoppingcartItem.Amount--;
                    localAmount = shoppingcartItem.Amount;


                }
            }
            else
            {
                DbContext.ShoppingCartItems.Remove(shoppingcartItem);
            }
            DbContext.SaveChanges();
            return localAmount;

        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                (ShoppingCartItems = 
                DbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Include(s => s.Item).ToList());
        }
        public void ClearCart()
        {
            var cartitems = DbContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);
            DbContext.ShoppingCartItems.RemoveRange(cartitems);
            DbContext.SaveChanges();
        }
        public decimal GetShoppingCartTotal()
        {
            var total = DbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Item.Price * c.Amount).Sum();
            return total;
        }


    }
}
