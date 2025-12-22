using System;
using InventorySystem.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InventorySystem.Domain.Entities.Order;

namespace ApplicationsLayer.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public string? ExternalReference { get; set; } //eg. supplier-order nr.
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderLineDTO> Lines { get; set; } = new();
    }
}