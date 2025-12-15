using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerstyring.Domain.Entities
{
    public class Productmovement
    {
        public int Movementid { get; }
        public int Productid { get; }
        public int Userid { get; }
        public int Quantity { get; set; }
        public Movementtype Type { get; set; }
        public DateTime Timestamp { get; set; }
        public Productmovement(int productid, int userid, int quantity, Movementtype type, DateTime timestamp)
        {
            Productid = productid;
            Userid = userid;
            Quantity = quantity;
            Type = type;
            Timestamp = timestamp;
        }
        public enum Movementtype
        {
            In,
            Out,
            Correction
        }
    }
}
