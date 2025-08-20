using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using TastyEats.Models;
using TastyEats.Data;

namespace TastyEats.Controllers
{
    public static class AuthController
    {
        //  Test hooks 
        internal static Func<string, Dictionary<string, object>, DataTable> Query =
            (sql, p) => DatabaseHandler.ExecuteQuery(sql, p);

        internal static Func<string, Dictionary<string, object>, int> NonQuery =
            (sql, p) => DatabaseHandler.ExecuteNonQuery(sql, p);

        //  Session 
        public static User? CurrentUser { get; private set; }
        public static bool IsLoggedIn => CurrentUser != null;
        public static bool IsAdmin => CurrentUser is Admin;

        //  Login 
        public static bool Login(string email, string password)
        {
            var user = GetCustomerByEmail(email) ?? (User?)GetAdminByEmail(email);
            if (AuthenticateResolvedUser(user, password))
            {
                SetActiveStatus(user!.Email, true);
                return true;
            }
            return false;
        }

        public static void Logout()
        {
            if (CurrentUser != null)
            {
                SetActiveStatus(CurrentUser.Email, false);
                CurrentUser = null;
            }
        }

        private static void SetActiveStatus(string email, bool isActive)
        {
            string table;
            var parameters = new Dictionary<string, object>
            {
                ["@active"] = isActive,
                ["@email"] = email
            };

            if (GetCustomerByEmail(email) != null)
                table = "customers";
            else if (GetAdminByEmail(email) != null)
                table = "admins";
            else
                return; // unknown user

            string sql = $"UPDATE {table} SET is_active = @active WHERE email = @email";
            NonQuery(sql, parameters);
        }

        //  Lookups
        public static Customer? GetCustomerByEmail(string email)
        {
            var dt = Query(
                "SELECT customer_id, name, email, password_hash, phone, address, is_active, created_at " +
                "FROM customers WHERE email = @email",
                new Dictionary<string, object> { ["@email"] = email });

            return dt.Rows.Count == 0 ? null : MapCustomer(dt.Rows[0]);
        }

        public static Admin? GetAdminByEmail(string email)
        {
            var dt = Query(
                "SELECT admin_id, name, email, password_hash, is_active, created_at " +
                "FROM admins WHERE email = @email",
                new Dictionary<string, object> { ["@email"] = email });

            return dt.Rows.Count == 0 ? null : MapAdmin(dt.Rows[0]);
        }

        public static Customer? GetCustomerById(int customerId)
        {
            var dt = Query(
                "SELECT customer_id, name, email, password_hash, phone, address, is_active, created_at " +
                "FROM customers WHERE customer_id = @id",
                new Dictionary<string, object> { ["@id"] = customerId });

            return dt.Rows.Count == 0 ? null : MapCustomer(dt.Rows[0]);
        }

        public static Admin? GetAdminById(int adminId)
        {
            var dt = Query(
                "SELECT admin_id, name, email, password_hash, is_active, created_at " +
                "FROM admins WHERE admin_id = @id",
                new Dictionary<string, object> { ["@id"] = adminId });

            return dt.Rows.Count == 0 ? null : MapAdmin(dt.Rows[0]);
        }

        // find user by email regardless the role (Customer or Admin)
        public static User? GetUserByEmail(string email) =>
            (User?)GetCustomerByEmail(email) ?? GetAdminByEmail(email);

        //  CRUD: Customers
        public static bool CreateCustomer(Customer c, string plainPassword)
        {
            const string sql = @"
                INSERT INTO customers (name, email, password_hash, phone, address, is_active, created_at)
                VALUES (@name, @email, @hash, @phone, @address, @active, @created)";
            var p = new Dictionary<string, object>
            {
                ["@name"] = c.Name,
                ["@email"] = c.Email,
                ["@hash"] = HashPassword(plainPassword),
                ["@phone"] = c.PhoneNumber ?? (object)DBNull.Value,
                ["@address"] = c.Address ?? (object)DBNull.Value,
                ["@active"] = c.IsActive,
                ["@created"] = c.CreatedAt
            };
            return NonQuery(sql, p) > 0;
        }

        public static bool UpdateCustomer(Customer c)
        {
            const string sql = @"
                UPDATE customers
                   SET name=@name, email=@email, phone=@phone, address=@address, is_active=@active
                 WHERE customer_id=@id";
            var p = new Dictionary<string, object>
            {
                ["@id"] = c.Id,
                ["@name"] = c.Name,
                ["@email"] = c.Email,
                ["@phone"] = c.PhoneNumber ?? (object)DBNull.Value,
                ["@address"] = c.Address ?? (object)DBNull.Value,
                ["@active"] = c.IsActive
            };
            return NonQuery(sql, p) > 0;
        }

        public static bool DeleteCustomer(int customerId)
        {
            const string sql = "DELETE FROM customers WHERE customer_id=@id";
            return NonQuery(sql, new Dictionary<string, object> { ["@id"] = customerId }) > 0;
        }

        //  CRUD: Admins 
        public static bool CreateAdmin(Admin a, string plainPassword)
        {
            const string sql = @"
                INSERT INTO admins (name, email, password_hash, is_active, created_at)
                VALUES (@name, @email, @hash, @active, @created)";
            var p = new Dictionary<string, object>
            {
                ["@name"] = a.Name,
                ["@email"] = a.Email,
                ["@hash"] = HashPassword(plainPassword),
                ["@active"] = a.IsActive,
                ["@created"] = a.CreatedAt
            };
            return NonQuery(sql, p) > 0;
        }

        public static bool UpdateAdmin(Admin a)
        {
            const string sql = @"
                UPDATE admins
                   SET name=@name, email=@email, is_active=@active
                 WHERE admin_id=@id";
            var p = new Dictionary<string, object>
            {
                ["@id"] = a.Id,
                ["@name"] = a.Name,
                ["@email"] = a.Email,
                ["@active"] = a.IsActive
            };
            return NonQuery(sql, p) > 0;
        }

        public static bool DeleteAdmin(int adminId)
        {
            const string sql = "DELETE FROM admins WHERE admin_id=@id";
            return NonQuery(sql, new Dictionary<string, object> { ["@id"] = adminId }) > 0;
        }

        //  Passwords 
        public static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(bytes);
        }

        public static bool VerifyPassword(string password, string hash) =>
            string.Equals((hash ?? "").Trim(), HashPassword(password),
                StringComparison.OrdinalIgnoreCase);

        //  Mappers 
        private static Customer MapCustomer(DataRow r) => new Customer
        {
            Id = Convert.ToInt32(r["customer_id"]),
            Name = r["name"]?.ToString() ?? "",
            Email = r["email"]?.ToString() ?? "",
            PasswordHash = r["password_hash"]?.ToString() ?? "",
            PhoneNumber = r.Table.Columns.Contains("phone") && r["phone"] != DBNull.Value ? r["phone"].ToString()! : "",
            Address = r.Table.Columns.Contains("address") && r["address"] != DBNull.Value ? r["address"].ToString()! : "",
            IsActive = r.Table.Columns.Contains("is_active") && r["is_active"] != DBNull.Value && Convert.ToBoolean(r["is_active"]),
            CreatedAt = r.Table.Columns.Contains("created_at") && r["created_at"] != DBNull.Value ? Convert.ToDateTime(r["created_at"]) : DateTime.UtcNow
        };

        private static Admin MapAdmin(DataRow r) => new Admin
        {
            Id = Convert.ToInt32(r["admin_id"]),
            Name = r["name"]?.ToString() ?? "",
            Email = r["email"]?.ToString() ?? "",
            PasswordHash = r["password_hash"]?.ToString() ?? "",
            IsActive = r.Table.Columns.Contains("is_active") && r["is_active"] != DBNull.Value && Convert.ToBoolean(r["is_active"]),
            CreatedAt = r.Table.Columns.Contains("created_at") && r["created_at"] != DBNull.Value ? Convert.ToDateTime(r["created_at"]) : DateTime.UtcNow
        };

        internal static bool AuthenticateResolvedUser(User? user, string password)
        {
            if (user == null) return false;
            if (!VerifyPassword(password, user.PasswordHash)) return false;

            CurrentUser = user;
            return true;
        }
    }
}
