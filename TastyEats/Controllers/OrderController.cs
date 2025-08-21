using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TastyEats.Data;
using TastyEats.Models;

namespace TastyEats.Controllers
{
    public class OrderController
    {

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
    }

}
