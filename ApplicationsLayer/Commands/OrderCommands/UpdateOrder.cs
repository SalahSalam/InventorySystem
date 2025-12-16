using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Commands.OrderCommands
{
    public class UpdateOrder
    {
        public int OrderID { get; set; } // Identifier for the order to update
        public DateTime OrderDate { get; set; }
        public int CustomerID { get; set; }
        public string Status { get; set; }
    }
}
