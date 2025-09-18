using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TastyEats.Models
{
    // Customer inherits from User
    public class Customer : User
    {
        
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

