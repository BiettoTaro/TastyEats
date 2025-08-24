using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TastyEats.Data;
using TastyEats.Models;

namespace TastyEats.Controllers
{
    public class OrderController
    {

        public static List<Order> GetAllOrders()
        {
            var orders = new List<Order>();

            // Query to get all orders
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

        public void AddOrder(Order order)
        {
            using (var conn = DatabaseHandler.GetConnection())
            {
                conn.Open();

                var cmdOrder = new NpgsqlCommand(@"
                INSERT INTO orders (customer_id, order_date, status, total_amount)
                VALUES (@customer_id, @order_date, @status, @total_amount)
                RETURNING order_id;
            ", conn);

                cmdOrder.Parameters.AddWithValue("@customer_id", order.CustomerId);
                cmdOrder.Parameters.AddWithValue("@order_date", order.OrderDate);
                cmdOrder.Parameters.AddWithValue("@status", order.Status);
                cmdOrder.Parameters.AddWithValue("@total_amount", order.TotalAmount);

                int orderId = Convert.ToInt32(cmdOrder.ExecuteScalar());
                order.OrderId = orderId;

                foreach (var item in order.Items)
                {
                    var cmdItem = new NpgsqlCommand(@"
                    INSERT INTO order_items (order_id, item_id, quantity, price_at_order)
                    VALUES (@order_id, @item_id, @quantity, @price_at_order);
                ", conn);

                    cmdItem.Parameters.AddWithValue("@order_id", orderId);
                    cmdItem.Parameters.AddWithValue("@item_id", item.ItemId);
                    cmdItem.Parameters.AddWithValue("@quantity", item.Quantity);
                    cmdItem.Parameters.AddWithValue("@price_at_order", item.PriceAtOrder);

                    cmdItem.ExecuteNonQuery();
                }
            }
        }

        public static List<Order> GetOrdersForCustomer(int customerId)
        {
            var orders = GetAllOrders(); // Or your DB fetch for all orders
            return orders.Where(o => o.CustomerId == customerId).ToList();
        }


    }

}
