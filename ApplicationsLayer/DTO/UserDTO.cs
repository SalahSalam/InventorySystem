using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.DTO
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; } = "";
        public string? Role { get; set; }
    }
}
