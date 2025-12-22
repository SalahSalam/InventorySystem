using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Domain.Entities
{
    public class InventoryItem
    {
        public int InventoryItemId { get; }
        public int ProductId { get; }
        public int LocationId { get; }
        public int Quantity { get; private set; }
        public DateTime LastUpdated { get; private set; }

        public InventoryItem(int inventoryItemId, int productId, int locationId, int quantity, DateTime lastupdated, int expectedQuantity)
        {
            InventoryItemId = inventoryItemId;
            ProductId = productId;
            LocationId = locationId;
            Quantity = quantity;
            LastUpdated = lastupdated;
            if (quantity < 0)
            {
                throw new ArgumentException("Quantity cannot be negative.");
            }
        }

        public void UpdateQuantity(int value)
        {
            if (Quantity + value < 0)
            {
                throw new ArgumentException("Quantity cannot be negative.");
            }
            Quantity += value;
            LastUpdated = DateTime.Now;
        }
    }
}