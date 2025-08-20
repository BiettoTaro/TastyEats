using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using TastyEats.Controllers;
using TastyEats.Data;
using TastyEats.Models;

namespace TastyEats.Tests.IntegrationTests
{
    [TestClass]
    public class AuthIntegrationTests
    {
        // Ensure the AuthController delegates point to the REAL DB for integration tests
        [ClassInitialize]
        public static void Bootstrap(TestContext _)
        {
            // Make sure we’re using the real DatabaseHandler (in case unit tests changed the delegates)
            AuthController.Query = (sql, p) => DatabaseHandler.ExecuteQuery(sql, p);
            AuthController.NonQuery = (sql, p) => DatabaseHandler.ExecuteNonQuery(sql, p);

            // Create tables if they don't exist
            const string ddl = @"
                CREATE TABLE IF NOT EXISTS customers (
                  customer_id SERIAL PRIMARY KEY,
                  name         TEXT NOT NULL,
                  email        TEXT NOT NULL UNIQUE,
                  password_hash TEXT NOT NULL,
                  phone        TEXT,
                  address      TEXT,
                  is_active    BOOLEAN NOT NULL DEFAULT TRUE,
                  created_at   TIMESTAMPTZ NOT NULL DEFAULT NOW()
                );
                CREATE TABLE IF NOT EXISTS admins (
                  admin_id     SERIAL PRIMARY KEY,
                  name         TEXT NOT NULL,
                  email        TEXT NOT NULL UNIQUE,
                  password_hash TEXT NOT NULL,
                  is_super     BOOLEAN NOT NULL DEFAULT FALSE,
                  is_active    BOOLEAN NOT NULL DEFAULT TRUE,
                  created_at   TIMESTAMPTZ NOT NULL DEFAULT NOW()
                );";
            DatabaseHandler.ExecuteNonQuery(ddl);
        }

        [TestInitialize]
        public void Reset()
        {
            // Use real DB delegates every test (unit tests may have overridden these statics)
            AuthController.Query = (sql, p) => DatabaseHandler.ExecuteQuery(sql, p);
            AuthController.NonQuery = (sql, p) => DatabaseHandler.ExecuteNonQuery(sql, p);

            // Clean DB state
            DatabaseHandler.ExecuteNonQuery("TRUNCATE TABLE customers RESTART IDENTITY CASCADE;");
            DatabaseHandler.ExecuteNonQuery("TRUNCATE TABLE admins RESTART IDENTITY CASCADE;");

            // Clear session
            AuthController.Logout();
        }

        [TestMethod]
        public void CreateCustomer_And_Login_Works_EndToEnd()
        {
            var c = new Customer
            {
                Name = "Integ Cust",
                Email = $"c_{Guid.NewGuid():N}@example.com",
                PhoneNumber = "07700 900111",
                Address = "1 Test St",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            var okCreate = AuthController.CreateCustomer(c, "pass123");
            Assert.IsTrue(okCreate, "Customer insert failed.");

            var okLogin = AuthController.Login(c.Email, "pass123");
            Assert.IsTrue(okLogin, "Login failed for inserted customer.");
            Assert.IsInstanceOfType(AuthController.CurrentUser, typeof(Customer));
            Assert.AreEqual(c.Email, AuthController.CurrentUser!.Email);
        }

        [TestMethod]
        public void CreateAdmin_And_Login_Works_EndToEnd()
        {
            var a = new Admin
            {
                Name = "Integ Admin",
                Email = $"a_{Guid.NewGuid():N}@example.com",
                isSuper = true,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            var okCreate = AuthController.CreateAdmin(a, "root");
            Assert.IsTrue(okCreate, "Admin insert failed.");

            var okLogin = AuthController.Login(a.Email, "root");
            Assert.IsTrue(okLogin, "Login failed for inserted admin.");
            Assert.IsTrue(AuthController.IsAdmin, "Session should be admin.");
            Assert.AreEqual(a.Email, AuthController.CurrentUser!.Email);
        }

        [TestMethod]
        public void Login_Fails_WithWrongPassword()
        {
            // seed a real customer
            var email = $"c_{Guid.NewGuid():N}@example.com";
            var c = new Customer
            {
                Name = "Wrong Pw",
                Email = email,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };
            Assert.IsTrue(AuthController.CreateCustomer(c, "correctpass"));

            var okLogin = AuthController.Login(email, "WRONG");
            Assert.IsFalse(okLogin);
            Assert.IsNull(AuthController.CurrentUser);
        }

        [TestMethod]
        public void UpdateCustomer_PersistsChanges()
        {
            var c = new Customer
            {
                Name = "Before",
                Email = $"c_{Guid.NewGuid():N}@example.com",
                PhoneNumber = "000",
                Address = "Old",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };
            Assert.IsTrue(AuthController.CreateCustomer(c, "x"));

            // fetch ID
            var saved = AuthController.GetCustomerByEmail(c.Email);
            Assert.IsNotNull(saved, "Inserted customer not found.");
            var id = saved!.Id;

            // update
            saved.Name = "After";
            saved.PhoneNumber = "999";
            saved.Address = "New";
            Assert.IsTrue(AuthController.UpdateCustomer(saved), "Update failed.");

            // verify
            var again = AuthController.GetCustomerById(id);
            Assert.IsNotNull(again);
            Assert.AreEqual("After", again!.Name);
            Assert.AreEqual("999", again.PhoneNumber);
            Assert.AreEqual("New", again.Address);
        }

        [TestMethod]
        public void DeleteAdmin_RemovesRow()
        {
            var a = new Admin
            {
                Name = "To Delete",
                Email = $"a_{Guid.NewGuid():N}@example.com",
                isSuper = false,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };
            Assert.IsTrue(AuthController.CreateAdmin(a, "z"));

            var saved = AuthController.GetAdminByEmail(a.Email);
            Assert.IsNotNull(saved);
            var id = saved!.Id;

            Assert.IsTrue(AuthController.DeleteAdmin(id), "Delete returned false.");

            var gone = AuthController.GetAdminById(id);
            Assert.IsNull(gone, "Row still present after delete.");
        }
    }
}
