using System;
using System.Collections.Generic;
using System.Data;
using TastyEats.Data;
using TastyEats.Models;

namespace TastyEats.Controllers
{
    public static class OrderItemController
    {
        public static List<OrderItem> GetOrderItems(int orderId)
        {
            var items = new List<OrderItem>();

            // Optionally join menu_items for name/desc
            var dt = DatabaseHandler.ExecuteQuery(
                @"SELECT order_item_id, order_id, item_id, price_at_order, quantity
                  FROM order_items
                  WHERE order_id = @orderId
                  ORDER BY order_item_id",
                new Dictionary<string, object>
                {
                    ["@orderId"] = orderId
                });

            foreach (DataRow row in dt.Rows)
            {
                items.Add(new OrderItem
                {
                    OrderItemId = Convert.ToInt32(row["order_item_id"]),
                    OrderId = Convert.ToInt32(row["order_id"]),
                    ItemId = Convert.ToInt32(row["item_id"]),
                    PriceAtOrder = Convert.ToDecimal(row["price_at_order"]),
                    Quantity = Convert.ToInt32(row["quantity"])
                });
            }

            return items;
        }

        
    }
}
