using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TastyEats.Data;
using TastyEats.Models;

namespace TastyEats.Controllers
{
    public static class OrderController
    {
        public static List<Order> GetAllOrders()
        {
            var orders = new List<Order>();
            var dt = DatabaseHandler.ExecuteQuery("SELECT * FROM orders ORDER BY order_id DESC", new Dictionary<string, object>());

            foreach (DataRow row in dt.Rows)
            {
                orders.Add(new Order
                {
                    OrderId = Convert.ToInt32(row["order_id"]),
                    CustomerId = Convert.ToInt32(row["customer_id"]),
                    OrderDate = Convert.ToDateTime(row["order_date"]),
                    TotalAmount = Convert.ToDecimal(row["total_amount"]),
                    Status = row["status"]?.ToString() ?? "Pending"
                });
            }

            return orders;
        }

        public static bool UpdateOrderStatus(int orderId, string status)
        {
            const string sql = @"UPDATE orders SET status = @status WHERE order_id = @id";
            var p = new Dictionary<string, object>
            {
                ["@id"] = orderId,
                ["@status"] = status
            };
            return DatabaseHandler.ExecuteNonQuery(sql, p) > 0;
        }

        public static Order AddOrder(Order order)
        {
            using (var conn = DatabaseHandler.GetConnection())
            {
                conn.Open();
                using var tx = conn.BeginTransaction();

                try
                {
                    // Insert order
                    var cmdOrder = new NpgsqlCommand(@"
                        INSERT INTO orders (customer_id, order_date, status, total_amount)
                        VALUES (@customer_id, @order_date, @status, @total_amount)
                        RETURNING order_id;
                    ", conn, tx);

                    cmdOrder.Parameters.AddWithValue("@customer_id", order.CustomerId);
                    cmdOrder.Parameters.AddWithValue("@order_date", order.OrderDate);
                    cmdOrder.Parameters.AddWithValue("@status", order.Status);
                    cmdOrder.Parameters.AddWithValue("@total_amount", order.TotalAmount);

                    order.OrderId = Convert.ToInt32(cmdOrder.ExecuteScalar());

                    // Insert order items
                    foreach (var item in order.Items)
                    {
                        var cmdItem = new NpgsqlCommand(@"
                            INSERT INTO order_items (order_id, item_id, quantity, price_at_order)
                            VALUES (@order_id, @item_id, @quantity, @price_at_order);
                        ", conn, tx);

                        cmdItem.Parameters.AddWithValue("@order_id", order.OrderId);
                        cmdItem.Parameters.AddWithValue("@item_id", item.ItemId);
                        cmdItem.Parameters.AddWithValue("@quantity", item.Quantity);
                        cmdItem.Parameters.AddWithValue("@price_at_order", item.PriceAtOrder);

                        cmdItem.ExecuteNonQuery();
                    }

                    tx.Commit();
                    return order;
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        public static List<Order> GetOrdersForCustomer(int customerId)
        {
            return GetAllOrders()
                .Where(o => o.CustomerId == customerId)
                .ToList();
        }
    }
}
