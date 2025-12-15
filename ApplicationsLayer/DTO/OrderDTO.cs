using System;
using InventorySystem.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.DTO
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = "";
        public List<OrderLineDTO> Items { get; set; } = new();
    }
}