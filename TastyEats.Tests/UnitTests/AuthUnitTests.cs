using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using TastyEats.Controllers;
using TastyEats.Models;

namespace TastyEats.Tests.UnitTests
{
    [TestClass]
    public class AuthUnitTests
    {
        [TestInitialize]
        public void Setup()
        {
            AuthController.Query = (sql, p) => new DataTable();
            AuthController.NonQuery = (sql, p) => 0;
            AuthController.Logout();
        }

        private static DataTable MakeCustomerTableRow(Customer c)
        {
            var t = new DataTable();
            t.Columns.Add("customer_id", typeof(int));
            t.Columns.Add("name", typeof(string));
            t.Columns.Add("email", typeof(string));
            t.Columns.Add("password_hash", typeof(string));
            t.Columns.Add("phone", typeof(string));
            t.Columns.Add("address", typeof(string));
            t.Columns.Add("is_active", typeof(bool));
            t.Columns.Add("created_at", typeof(DateTime));

            t.Rows.Add(c.Id, c.Name, c.Email, c.PasswordHash, c.PhoneNumber, c.Address, c.IsActive, c.CreatedAt);
            return t;
        }

        private static DataTable MakeAdminTableRow(Admin a)
        {
            var t = new DataTable();
            t.Columns.Add("admin_id", typeof(int));
            t.Columns.Add("name", typeof(string));
            t.Columns.Add("email", typeof(string));
            t.Columns.Add("password_hash", typeof(string));
            t.Columns.Add("is_active", typeof(bool));
            t.Columns.Add("created_at", typeof(DateTime));

            t.Rows.Add(a.Id, a.Name, a.Email, a.PasswordHash, a.IsActive, a.CreatedAt);
            return t;
        }

        [TestMethod]
        public void Login_AsCustomer_Succeeds_WhenPasswordMatches()
        {
            const string plain = "pass123";
            var cust = new Customer
            {
                Id = 101,
                Name = "Cus T. Omer",
                Email = "cust@example.com",
                PasswordHash = AuthController.HashPassword(plain),
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            AuthController.Logout();

            var ok = AuthController.AuthenticateResolvedUser(cust, plain);

            Assert.IsTrue(ok);
            Assert.IsNotNull(AuthController.CurrentUser);
            Assert.IsInstanceOfType(AuthController.CurrentUser, typeof(Customer));
            Assert.AreEqual("cust@example.com", AuthController.CurrentUser!.Email);
        }

        [TestMethod]
        public void AuthenticateResolvedUser_Fails_WhenPasswordWrong()
        {
            const string plain = "pass123";
            var cust = new Customer
            {
                Id = 1,
                Name = "X",
                Email = "x@example.com",
                PasswordHash = AuthController.HashPassword(plain)
            };

            AuthController.Logout();

            var ok = AuthController.AuthenticateResolvedUser(cust, "wrong");
            Assert.IsFalse(ok);
            Assert.IsNull(AuthController.CurrentUser);
        }

        [TestMethod]
        public void AuthenticateResolvedUser_Fails_WhenUserNull()
        {
            AuthController.Logout();
            var ok = AuthController.AuthenticateResolvedUser(null, "anything");
            Assert.IsFalse(ok);
            Assert.IsNull(AuthController.CurrentUser);
        }

        [TestMethod]
        public void Login_FallsBackToAdmin_WhenNotCustomer()
        {
            var admin = new Admin
            {
                Id = 7,
                Name = "Ad Min",
                Email = "admin@example.com",
                PasswordHash = AuthController.HashPassword("root"),
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            AuthController.Query = (sql, p) =>
                sql.Contains("FROM customers", StringComparison.OrdinalIgnoreCase)
                    ? new DataTable()
                    : MakeAdminTableRow(admin);

            var ok = AuthController.Login("admin@example.com", "root");

            Assert.IsTrue(ok);
            Assert.IsTrue(AuthController.IsAdmin);
            Assert.AreEqual("admin@example.com", AuthController.CurrentUser!.Email);
        }

        [TestMethod]
        public void Login_Fails_WhenWrongPassword()
        {
            const string correct = "pass123";
            var cust = new Customer
            {
                Id = 202,
                Name = "Wrong Pass",
                Email = "wp@example.com",
                PasswordHash = AuthController.HashPassword(correct),
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            var ok = AuthController.Login("wp@example.com", "wrong");

            Assert.IsFalse(ok);
            Assert.IsNull(AuthController.CurrentUser);
        }

        [TestMethod]
        public void CreateCustomer_ReturnsTrue_WhenNonQueryAffectsRow()
        {
            var c = new Customer
            {
                Name = "New C",
                Email = "newc@example.com",
                PhoneNumber = "555",
                Address = "Somewhere",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            AuthController.NonQuery = (sql, p) =>
                sql.IndexOf("INSERT INTO customers", StringComparison.OrdinalIgnoreCase) >= 0 ? 1 : 0;

            Assert.IsTrue(AuthController.CreateCustomer(c, "secret"));
        }

        [TestMethod]
        public void UpdateAdmin_ReturnsFalse_WhenNoRowsAffected()
        {
            var a = new Admin
            {
                Id = 9,
                Name = "Admin Nine",
                Email = "a9@example.com",
                IsActive = true
            };

            AuthController.NonQuery = (sql, p) => 0;

            Assert.IsFalse(AuthController.UpdateAdmin(a));
        }

        [TestMethod]
        public void GetUserByEmail_ReturnsCustomer_FirstIfBothExist()
        {
            var cust = new Customer
            {
                Id = 1,
                Name = "Overlap",
                Email = "same@example.com",
                PasswordHash = AuthController.HashPassword("x"),
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };
            var admin = new Admin
            {
                Id = 2,
                Name = "Overlap Admin",
                Email = "same@example.com",
                PasswordHash = AuthController.HashPassword("x"),
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            AuthController.Query = (sql, p) =>
                sql.Contains("FROM customers", StringComparison.OrdinalIgnoreCase)
                    ? MakeCustomerTableRow(cust)
                    : MakeAdminTableRow(admin);

            var user = AuthController.GetUserByEmail("same@example.com");
            Assert.IsNotNull(user);
            Assert.IsInstanceOfType(user, typeof(Customer));
        }
    }
}
