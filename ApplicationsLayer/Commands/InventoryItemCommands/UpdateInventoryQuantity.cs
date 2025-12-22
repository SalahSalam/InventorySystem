using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Commands.Inventoryitem
{
    public class UpdateInventoryQuantity
    {
        public int InventoryItemId { get; set; }
        public int QuantityChange { get; set; }
        public int UserId { get; set; }
        public int? FromLocationId { get; set; }
        public int? ToLocationId { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}
