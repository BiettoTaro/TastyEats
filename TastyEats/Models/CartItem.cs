using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TastyEats.Models
{
    public class CartItem
    {
        public Guid LineId { get; set; } = Guid.NewGuid();
        public int ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; } = string.Empty;
        public decimal TotalPrice 
        { 
            get 
            { 
                return Price * Quantity; 
            }
        }
    }
}
