using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.DTO
{
    public class InventoryItemDTO
    {
        public int InventoryItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public int LocationId { get; set; }
        public string LocationName { get; set; } = "";
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
