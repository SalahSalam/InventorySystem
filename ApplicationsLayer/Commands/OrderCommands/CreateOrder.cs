using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Commands.OrderCommands
{
    public class CreateOrder
    {
        public int OrderId { get; }
        public List<CreateOrderItem> Items { get; set; } = new();
    }
    public class CreateOrderItem
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
