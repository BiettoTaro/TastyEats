using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TastyEats.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public string Image { get; set; } = ""; // this is the important one
        public int CategoryId { get; set; }
        public int AdminId { get; set; }
        public bool IsAvailable { get; set; }
    }
}

