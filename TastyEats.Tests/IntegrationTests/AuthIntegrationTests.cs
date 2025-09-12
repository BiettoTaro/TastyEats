using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TastyEats.Controllers;
using TastyEats.Data;
using TastyEats.Models;

namespace TastyEats.Tests.IntegrationTests
{
    [TestClass]
    public class AuthIntegrationTests
    {
        private static void EnsureTestDatabase()
        {
            using var conn = DatabaseHandler.GetConnection();
            if (!conn.ConnectionString.Contains("tastyeats_test", StringComparison.OrdinalIgnoreCase))
            {
                Assert.Fail("⚠️ Tests must run against 'tastyeats_test'. Aborting to protect production DB.");
            }
        }

        [ClassInitialize]
        public static void Bootstrap(TestContext _)
        {
            EnsureTestDatabase();

            // Hook AuthController into real DB
            AuthController.Query = (sql, p) => DatabaseHandler.ExecuteQuery(sql, p);
            AuthController.NonQuery = (sql, p) => DatabaseHandler.ExecuteNonQuery(sql, p);

            const string ddl = @"
                CREATE TABLE IF NOT EXISTS customers (
                  customer_id   SERIAL PRIMARY KEY,
                  name          TEXT NOT NULL,
                  email         TEXT NOT NULL UNIQUE,
                  password_hash TEXT NOT NULL,
                  phone         TEXT NOT NULL,
                  address       TEXT NOT NULL,
                  is_active     BOOLEAN NOT NULL DEFAULT TRUE,
                  created_at    TIMESTAMPTZ NOT NULL DEFAULT NOW()
                );
                CREATE TABLE IF NOT EXISTS admins (
                  admin_id      SERIAL PRIMARY KEY,
                  name          TEXT NOT NULL,
                  email         TEXT NOT NULL UNIQUE,
                  password_hash TEXT NOT NULL,
                  is_active     BOOLEAN NOT NULL DEFAULT TRUE,
                  admin_role    TEXT NOT NULL DEFAULT 'Staff',
                  created_at    TIMESTAMPTZ NOT NULL DEFAULT NOW()
                );";
            DatabaseHandler.ExecuteNonQuery(ddl);
        }

        [TestInitialize]
        public void Reset()
        {
            EnsureTestDatabase();
            DatabaseHandler.ExecuteNonQuery("TRUNCATE TABLE customers RESTART IDENTITY CASCADE;");
            DatabaseHandler.ExecuteNonQuery("TRUNCATE TABLE admins RESTART IDENTITY CASCADE;");
            AuthController.Logout();
            typeof(AuthController).GetProperty("CurrentUser")!.SetValue(null, null); // hard reset
        }

        [TestMethod]
        public void CreateCustomer_And_Login_Works()
        {
            var email = $"c_{Guid.NewGuid():N}".Substring(0, 8) + "@test.com";
            var c = new Customer
            {
                Name = "Test Customer",
                Email = email,
                PhoneNumber = "07700900111",
                Address = "1 Test St",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            var okCreate = AuthController.CreateCustomer(c, "pass123");
            Assert.IsTrue(okCreate, "Customer insert failed.");

            var check = AuthController.GetCustomerByEmail(c.Email);
            Assert.IsNotNull(check, "Customer not found in DB after insert.");

            var okLogin = AuthController.Login(c.Email, "pass123");
            Assert.IsTrue(okLogin, "Login failed after insert.");
            Assert.IsInstanceOfType(AuthController.CurrentUser, typeof(Customer), "Logged in user should be a Customer.");
            Assert.AreEqual(c.Email, AuthController.CurrentUser!.Email);
        }

        [TestMethod]
        public void CreateAdmin_And_Login_Works()
        {
            var email = $"a_{Guid.NewGuid():N}".Substring(0, 8) + "@test.com";
            var a = new Admin
            {
                Name = "Test Admin",
                Email = email,
                Role = "Staff",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            var okCreate = AuthController.CreateAdmin(a, "root");
            Assert.IsTrue(okCreate, "Admin insert failed.");

            var check = AuthController.GetAdminByEmail(a.Email);
            Assert.IsNotNull(check, "Admin not found in DB after insert.");

            var okLogin = AuthController.Login(a.Email, "root");
            Assert.IsTrue(okLogin, "Login failed after admin insert.");
            Assert.IsTrue(AuthController.IsAdmin, "Session should be admin after login.");
            Assert.AreEqual(a.Email, AuthController.CurrentUser!.Email);
        }

        [TestMethod]
        public void Login_Fails_WithWrongPassword()
        {
            var email = $"c_{Guid.NewGuid():N}".Substring(0, 8) + "@test.com";
            var c = new Customer
            {
                Name = "Wrong Pw",
                Email = email,
                PhoneNumber = "0000000000",
                Address = "123 Test Street",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            Assert.IsTrue(AuthController.CreateCustomer(c, "correctpass"), "Customer insert failed.");

            var okLogin = AuthController.Login(email, "WRONG");
            Assert.IsFalse(okLogin, "Login should fail with wrong password.");
            Assert.IsNull(AuthController.CurrentUser, "CurrentUser should remain null after failed login.");
        }

        [TestMethod]
        public void UpdateCustomer_PersistsChanges()
        {
            var email = $"c_{Guid.NewGuid():N}".Substring(0, 8) + "@test.com";
            var c = new Customer
            {
                Name = "Before",
                Email = email,
                PhoneNumber = "000",
                Address = "Old",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            Assert.IsTrue(AuthController.CreateCustomer(c, "x"), "Customer insert failed.");

            var saved = AuthController.GetCustomerByEmail(email);
            Assert.IsNotNull(saved, "Inserted customer not found.");
            var id = saved!.Id;

            saved.Name = "After";
            saved.PhoneNumber = "999";
            saved.Address = "New";
            Assert.IsTrue(AuthController.UpdateCustomer(saved), "Update failed.");

            var again = AuthController.GetCustomerById(id);
            Assert.IsNotNull(again, "Updated customer not found.");
            Assert.AreEqual("After", again!.Name);
            Assert.AreEqual("999", again.PhoneNumber);
            Assert.AreEqual("New", again.Address);
        }

        [TestMethod]
        public void DeleteAdmin_RemovesRow()
        {
            var email = $"a_{Guid.NewGuid():N}".Substring(0, 8) + "@test.com";
            var a = new Admin
            {
                Name = "To Delete",
                Email = email,
                Role = "Staff",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            Assert.IsTrue(AuthController.CreateAdmin(a, "z"), "Admin insert failed.");

            var saved = AuthController.GetAdminByEmail(email);
            Assert.IsNotNull(saved, "Inserted admin not found.");
            var id = saved!.Id;

            Assert.IsTrue(AuthController.DeleteAdmin(id), "Delete returned false.");

            var gone = AuthController.GetAdminById(id);
            Assert.IsNull(gone, "Row still present after delete.");
        }
    }
}
