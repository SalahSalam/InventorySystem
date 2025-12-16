using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Commands.Inventoryitem
{
    public class UpdateInventoryitem
    {
        public int InventoryItemID { get; set; } // or get; init; if immutable
        public int Quantity { get; set; }
        public int ExpectedQuantity { get; set; }
    }
}
