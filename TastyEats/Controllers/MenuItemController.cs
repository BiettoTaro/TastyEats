using System;
using System.Collections.Generic;
using System.Data;
using TastyEats.Data;
using TastyEats.Models;

namespace TastyEats.Controllers
{
    public static class MenuItemController
    {
        public static List<MenuItem> GetAllMenuItems()
        {
            var dt = DatabaseHandler.ExecuteQuery("SELECT * FROM menu_items ORDER BY item_id", new Dictionary<string, object>());
            var items = new List<MenuItem>();
            foreach (DataRow row in dt.Rows)
                items.Add(MapMenuItem(row));
            return items;
        }

        public static bool AddMenuItem(MenuItem item)
        {
            const string sql = @"
                INSERT INTO menu_items (name, description, price, image_path, category_id, admin_id, is_available)
                VALUES (@name, @desc, @price, @image, @cat, @admin, @avail)";
            var p = new Dictionary<string, object>
            {
                ["@name"] = item.Name,
                ["@desc"] = item.Description ?? "",
                ["@price"] = item.Price,
                ["@image"] = item.Image ?? "",
                ["@cat"] = item.CategoryId,
                ["@admin"] = item.AdminId,
                ["@avail"] = item.IsAvailable
            };
            return DatabaseHandler.ExecuteNonQuery(sql, p) > 0;
        }

        public static bool UpdateMenuItem(MenuItem item)
        {
            const string sql = @"
                UPDATE menu_items
                   SET name=@name,
                       description=@desc,
                       price=@price,
                       image_path=@image,
                       category_id=@cat,
                       admin_id=@admin,
                       is_available=@avail
                 WHERE item_id=@id";
            var p = new Dictionary<string, object>
            {
                ["@id"] = item.Id,
                ["@name"] = item.Name,
                ["@desc"] = item.Description ?? "",
                ["@price"] = item.Price,
                ["@image"] = item.Image ?? "",
                ["@cat"] = item.CategoryId,
                ["@admin"] = item.AdminId,
                ["@avail"] = item.IsAvailable
            };
            return DatabaseHandler.ExecuteNonQuery(sql, p) > 0;
        }

        public static bool DeleteMenuItem(int itemId)
        {
            const string sql = "DELETE FROM menu_items WHERE item_id=@id";
            return DatabaseHandler.ExecuteNonQuery(sql, new Dictionary<string, object> { ["@id"] = itemId }) > 0;
        }

        private static MenuItem MapMenuItem(DataRow r)
        {
            return new MenuItem
            {
                Id = Convert.ToInt32(r["item_id"]),
                Name = r["name"]?.ToString() ?? "",
                Description = r["description"]?.ToString() ?? "",
                Price = Convert.ToDecimal(r["price"]),
                Image = r["image_path"]?.ToString() ?? "",
                CategoryId = Convert.ToInt32(r["category_id"]),
                AdminId = Convert.ToInt32(r["admin_id"]),
                IsAvailable = r.Table.Columns.Contains("is_available") && r["is_available"] != DBNull.Value && Convert.ToBoolean(r["is_available"])
            };
        }
    }
}
