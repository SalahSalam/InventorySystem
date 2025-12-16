using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.DTO
{
    public class InventoryItemDTO
    {
        public int InventoryItemID { get; set; }
        public int ProductID { get; set; }
        public int LocationID { get; set; }
        public int Quantity { get; set; }
        public int ExpectedQuantity { get; init; }
        public DateTime LastUpdated { get; set; }
    }
}
