using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Domain.Entities
{
    public class User
    {
        public int UserId { get; }
        public string Name { get; set; }
        public string Role { get; set; }
        public User(string name, string role)
        {
            Name = name;
            Role = role;
        }
    }
}
