using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applikationslag.Commands.OrderCommands
{
    public class UpdateOrder
    {
        public int OrderId { get; }
        public string? NewStatus { get; set; }
    }
}
