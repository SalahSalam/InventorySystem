using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.DTO
{
    public class InventoryItemDTO
    {
        public int InventoryItemID { get; }
        public int ProductID { get; }
        public int LocationID { get; }
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
