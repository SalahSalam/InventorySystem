using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Commands.OrderCommands
{
    public class CreateOrder
    {
        public List<CreateOrderLine> Lines { get; set; } = new();
    }
    public class CreateOrderLine
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
