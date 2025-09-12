using System;
using System.Collections.Generic;
using System.Linq;
using TastyEats.Models;

namespace TastyEats.Controllers
{
    internal static class CartController
    {
        // Delegate and Event for UI updates
        public delegate void CartChangedHandler(CartItem? item, string action);
        public static event CartChangedHandler? OnCartChanged;

        public static void AddToCart(CartItem item)
        {
            var existingItem = Cart.Items.FirstOrDefault(i =>
                i.ItemId == item.ItemId && i.Notes == item.Notes);

            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
                OnCartChanged?.Invoke(existingItem, "Updated");
            }
            else
            {
                Cart.Items.Add(item);
                OnCartChanged?.Invoke(item, "Added");
            }
        }

        public static void RemoveOne(Guid lineId)
        {
            var line = FindLine(lineId);
            if (line == null) return;

            if (line.Quantity > 1)
            {
                line.Quantity--;
                OnCartChanged?.Invoke(line, "Decremented");
            }
            else
            {
                Cart.Items.Remove(line);
                OnCartChanged?.Invoke(line, "Removed");
            }
        }

        public static void RemoveLine(Guid lineId)
        {
            var line = FindLine(lineId);
            if (line == null) return;

            Cart.Items.Remove(line);
            OnCartChanged?.Invoke(line, "Removed");
        }

        public static void UpdateLine(Guid lineId, int newQuantity, string newNotes)
        {
            var line = FindLine(lineId);
            if (line == null) return;

            if (newQuantity <= 0)
            {
                Cart.Items.Remove(line);
                OnCartChanged?.Invoke(line, "Removed");
                return;
            }

            line.Quantity = newQuantity;
            line.Notes = newNotes ?? string.Empty;
            OnCartChanged?.Invoke(line, "Updated");
        }

        public static void ClearCart()
        {
            Cart.Items.Clear();
            OnCartChanged?.Invoke(null, "Cleared");
        }

        // Helpers with LINQ
        public static decimal GetTotalPrice() => Cart.Items.Sum(i => i.TotalPrice);
        public static IReadOnlyList<CartItem> GetItems() => Cart.Items.ToList();

        // Helper for first or default refactoring
        private static CartItem? FindLine(Guid lineId) =>
            Cart.Items.FirstOrDefault(i => i.LineId == lineId);
    }
}
