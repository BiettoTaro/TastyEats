using System;
using System.Collections.Generic;
using System.Data;
using TastyEats.Models;
using TastyEats.Controllers;

namespace TastyEats.Data
{
    public static class DatabaseSeeder
    {
        public static void Seed()
        {
            SeedAdmin();
            SeedCategories();
            SeedMenuItems();
        }

        private static void SeedAdmin()
        {
            // Default admin
            var existing = AuthController.GetAdminByEmail("admin@example.com");
            if (existing == null)
            {
                var admin = new Admin
                {
                    Name = "Admin",
                    Email = "admin@example.com",
                    PasswordHash = "",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                };
                AuthController.CreateAdmin(admin, "password"); // default password
            }

            
        }


        private static void SeedCategories()
        {
            var categories = new[]
            {
                new Category { Name = "Starters" },
                new Category { Name = "Mains" },
                new Category { Name = "Desserts" },
                new Category { Name = "Drinks"}
            };

            foreach (var cat in categories)
            {
                string query = "INSERT INTO categories (name) VALUES (@name) ON CONFLICT DO NOTHING";
                DatabaseHandler.ExecuteNonQuery(query, new Dictionary<string, object> { ["@name"] = cat.Name });
            }
        }

        private static void SeedMenuItems()
        {
            var items = new[]
            {
                new { Id = 1, Name = "Cozze Gratinate", Desc = "Gratinated mussels with herbs and breadcrumbs", Price = 13.00m, Img = "images/cozze_gratinate.jpg", Cat = 1 },
                new { Id = 2, Name = "Insalata di Polpi", Desc = "Octopus salad with potatoes, celery, and parsley", Price = 15.00m, Img = "images/insalata_di_polpi.jpg", Cat = 1 },
                new { Id = 3, Name = "Tagliere Salumi & Formaggi", Desc = "Charcuterie board with cured meats and cheese", Price = 12.00m, Img = "images/tagliere_salumi.jpg", Cat = 1 },
                new { Id = 4, Name = "Fregola allo Scoglio", Desc = "Sardinian pasta with seafood", Price = 25.00m, Img = "images/fregola.jpg", Cat = 2 },
                new { Id = 5, Name = "Porcetto con Patate", Desc = "Roasted suckling pig with potatoes", Price = 27.00m, Img = "images/porcetto.jpg", Cat = 2 },
                new { Id = 6, Name = "Zuppa Gallurese", Desc = "Sardinian dish made with bread, cheese and ewe broth", Price = 20.00m, Img = "images/zuppa_gallurese.jpg", Cat = 2 },
                new { Id = 7, Name = "Seadas", Desc = "Sardinian pastry filled with cheese served with sugar or honey", Price = 10.00m, Img = "images/seadas.jpg", Cat = 3 },
                new { Id = 8, Name = "Tiramisu", Desc = "Classic italian dessert made with ladyfingers, mascarpone and coffee", Price = 9.00m, Img = "images/tiramisu.jpg", Cat = 3 },
                new { Id = 9, Name = "Panna Cotta", Desc = "Classic italian dessert served with fresh berries", Price = 8.00m, Img = "images/panna_cotta.jpg", Cat = 3 },
            };

            foreach (var i in items)
            {
                string query = @"
                    INSERT INTO menu_items (item_id, name, description, price, image_path, category_id, admin_id, is_available)
                    VALUES (@id, @name, @desc, @price, @img, @cat, 1, TRUE)
                    ON CONFLICT (item_id) DO NOTHING";
                var p = new Dictionary<string, object>
                {
                    ["@id"] = i.Id,
                    ["@name"] = i.Name,
                    ["@desc"] = i.Desc,
                    ["@price"] = i.Price,
                    ["@img"] = i.Img,
                    ["@cat"] = i.Cat
                };
                DatabaseHandler.ExecuteNonQuery(query, p);
            }
        }
    }
}
