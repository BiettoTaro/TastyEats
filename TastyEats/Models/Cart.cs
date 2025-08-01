using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TastyEats.Models
{
    internal class Cart
    {
        public static List<CartItem> Items { get; set; } = new List<CartItem>();
       
    }
}
