using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Domain.Entities
{
    public class Orderline
    {
        public int OrderLineID { get; }
        public int OrderID { get; }
        public int ProductID { get; }
        public int Quantity { get; set; }
        public Orderline(int orderID, int productID, int quantity)
        {
            OrderID = orderID;
            ProductID = productID;
            Quantity = quantity;
        }
    }
}
