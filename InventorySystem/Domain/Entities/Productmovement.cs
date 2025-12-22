using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Domain.Entities
{
    public class ProductMovement
    {
        public int MovementId { get; }
        public int ProductId { get; }
        public int UserId { get; }
        public int? FromLocationId { get; }
        public int? ToLocationId { get; }
        public int Quantity { get; set; }
        public MovementType Type { get; set; }
        public DateTime Timestamp { get; set; }
        public ProductMovement(int productId, int userId, int? fromLocationId, int? toLocationId, int quantity, MovementType type, DateTime timestamp)
        {
            ProductId = productId;
            UserId = userId;
            FromLocationId = fromLocationId;
            ToLocationId = toLocationId;
            Quantity = quantity;
            Type = type;
            Timestamp = timestamp;
        }
        public enum MovementType
        {
            In,
            Out,
            Correction
        }
    }
}
