using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TastyEats.Models
{
    public class Admin : User
    {
        
  
        public bool IsActive { get; set; } = true;
        public string Role { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

