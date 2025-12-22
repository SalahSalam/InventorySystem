using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InventorySystem.Domain.Entities.ProductMovement;

namespace ApplicationsLayer.DTO
{
    public class ProductMovementDTO
    {
        public int Movementid { get;  set; }
        public int Productid { get; set; }
        public string ProductName { get; set; } = "";
        public int? FromLocationId { get; set; }
        public int? ToLocationId { get; set; }
        public int Userid { get; set; }
        public string UserName { get; set; } = "";
        public int Quantity { get; set; }
        public MovementType Type { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
