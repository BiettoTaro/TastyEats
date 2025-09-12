using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TastyEats.Data;
using TastyEats.Models;
using TastyEats.Properties;


namespace TastyEats.Controllers
{
    public static class MenuItemController
    {
        //  Delegate + Event
        public delegate void MenuChangedHandler(MenuItem item, string action);
        public static event MenuChangedHandler? OnMenuChanged;

        public static List<MenuItem> GetAllMenuItems()
        {
            var dt = DatabaseHandler.ExecuteQuery(
                "SELECT item_id, name, description, price, image_path, category_id, admin_id, is_available FROM menu_items ORDER BY item_id"
            );

            return dt.AsEnumerable()
                     .Select(MapMenuItem)
                     .ToList();
        }


        public static bool AddMenuItem(MenuItem item)
        {
            const string sql = @"
                INSERT INTO menu_items (name, description, price, image_path, category_id, admin_id, is_available)
                VALUES (@name, @desc, @price, @image, @cat, @admin, @avail)";

            var success = DatabaseHandler.ExecuteNonQuery(sql, BuildParameters(item)) > 0;
            if (success) OnMenuChanged?.Invoke(item, "Added");
            return success;
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

            var success = DatabaseHandler.ExecuteNonQuery(sql, BuildParameters(item, true)) > 0;
            if (success) OnMenuChanged?.Invoke(item, "Updated");
            return success;
        }


        public static bool DeleteMenuItem(int itemId)
        {
            const string sql = "DELETE FROM menu_items WHERE item_id=@id";
            var success = DatabaseHandler.ExecuteNonQuery(sql, new Dictionary<string, object> { ["@id"] = itemId }) > 0;

            if (success) OnMenuChanged?.Invoke(new MenuItem { Id = itemId }, "Deleted");
            return success;
        }

        //  helper with LINQ
        private static MenuItem MapMenuItem(DataRow r) => new MenuItem
        {
            Id = Convert.ToInt32(r["item_id"]),
            Name = r["name"]?.ToString() ?? "",
            Description = r["description"]?.ToString() ?? "",
            Price = Convert.ToDecimal(r["price"]),
            Image = string.IsNullOrWhiteSpace(r["image_path"]?.ToString())
            ? "Resources/placeholder.png"   // fallback path
            : r["image_path"]?.ToString() ?? "",
            CategoryId = Convert.ToInt32(r["category_id"]),
            AdminId = Convert.ToInt32(r["admin_id"]),
            IsAvailable = r.Table.Columns.Contains("is_available")
                          && r["is_available"] != DBNull.Value
                          && Convert.ToBoolean(r["is_available"])
        };

        // Helper to refactor common code
        private static Dictionary<string, object> BuildParameters(MenuItem item, bool includeId = false)
        {
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

            if (includeId) p["@id"] = item.Id;

            return p;
        }

    }
}
