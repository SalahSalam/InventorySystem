using InventorySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Commands.ProductMovementCommands
{
    public class UpdateProductMovement
    {
        public int Movementid { get; }
        public int Productid { get; }
        public int Quantity { get; set; }
        public ProductMovement.Movementtype Type { get; set; }
    }
}
