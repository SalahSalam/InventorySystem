using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Commands.Inventoryitem
{
    public class CreateInventoryitem
    {
        public int InventoryItemID { get; init; }
        public int ProductID { get; init; }
        public int LocationID { get; init; }
        public int Quantity { get; init; }
        public int ExpectedQuantity { get; init; }

    }
}
