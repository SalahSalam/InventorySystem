using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applikationslag.Commands.ProductCommands
{
    public class CreateProduct
    {
        public int Productid { get; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
        public int Minimumstock { get; set; }
    }
}
