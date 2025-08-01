using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TastyEats.Models;

namespace TastyEats.Controllers
{
    internal class CartController
    {
        public static void AddToCart(CartItem item)
        {
            var existingItem = Cart.Items.Find(i => i.ItemId == item.ItemId);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                Cart.Items.Add(item);
            }
        }
        public static void RemoveFromCart(int itemId)
        {
            var item = Cart.Items.Find(i => i.ItemId == itemId);
            if (item != null)
            {
                Cart.Items.Remove(item);
            }
        }

        public static void ClearCart()
        {
            Cart.Items.Clear();
        }

        public static decimal GetTotalPrice()
        {
            return Cart.Items.Sum(i => i.TotalPrice);
        }
    }
}
