using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lagerstyring.Domain.Entities.Productmovement;

namespace Applikationslag.DTO
{
    public class ProductMovementDTO
    {
        public int Movementid { get; }
        public int Productid { get; }
        public int Userid { get; }
        public int Quantity { get; set; }
        public Movementtype Type { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
