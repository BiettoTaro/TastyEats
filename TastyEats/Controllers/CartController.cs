using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TastyEats.Models;

namespace TastyEats.Controllers
{
    internal class CartController
    {
        public static void AddToCart(CartItem item)
        {
            var existingItem = Cart.Items.FirstOrDefault(i => i.ItemId == item.ItemId &&
            i.Notes == item.Notes);

            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                Cart.Items.Add(item);
            }
        }
        public static void RemoveOne(Guid lineId)
        {
            var line = Cart.Items.FirstOrDefault(i => i.LineId == lineId);

            if (line == null) return;

            if(line.Quantity > 1) line.Quantity--;
            else Cart.Items.Remove(line);
            
        }

        public  static void RemoveLine(Guid LineId)
        {
            var line = Cart.Items.FirstOrDefault(i => i.LineId == LineId);
            if (line != null) Cart.Items.Remove(line);
            
        }

        public static void UpdateLine(Guid lineId, int newQuantity, string newNotes)
        {
            var line = Cart.Items.FirstOrDefault(i => i.LineId == lineId);
            if (line == null) return;

            if (newQuantity <= 0)
            {
                Cart.Items.Remove(line);
                return;
            }

            line.Quantity = newQuantity;
            line.Notes = newNotes ?? string.Empty;
        }

        public static void ClearCart()
        {
            Cart.Items.Clear();
        }

        public static decimal GetTotalPrice() => Cart.Items.Sum(i => i.TotalPrice);
        public static IReadOnlyList<CartItem> GetItems() => Cart.Items.ToList();
       

    }
}
