using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Commands.LocationCommands
{
    public class CreateLocation
    {
        public string Name { get; set; } = "";
        public string? Description { get; set; }
    }
}
