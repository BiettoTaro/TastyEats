using System;
using System.Linq;
using TastyEats.Models;

namespace TastyEats.Controllers
{
    internal static class PaymentController
    {
        public static Order ProcessOrder(User user, string paymentMethod)
        {
            if (user == null)
                throw new InvalidOperationException("User must be logged in.");

            var order = new Order
            {
                CustomerId = user.Id,
                OrderDate = DateTime.Now,
                Status = "Pending",
                TotalAmount = CartController.GetTotalPrice(),
                Items = CartController.GetItems()
                    .Select(ci => new OrderItem
                    {
                        ItemId = ci.ItemId,
                        Quantity = ci.Quantity,
                        PriceAtOrder = ci.Price
                    })
                    .ToList()
            };

            // Call static OrderController directly
            var savedOrder = OrderController.AddOrder(order);

            CartController.ClearCart();
            return savedOrder;
        }
    }
}
