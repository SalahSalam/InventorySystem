using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Domain.Entities
{
    public class Order
    {
        private readonly List<OrderLine> _lines = new();   //private to enforce composition

        public int OrderId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public OrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderLine> Lines => _lines.AsReadOnly();

        private Order() { } // For EF core to materialze
        public Order(IEnumerable<OrderLine> lines)
        {
            if (lines == null || !lines.Any())
                throw new ArgumentException("An order must contain at least one order line.");

            CreatedAt = DateTime.UtcNow;
            Status = OrderStatus.Open;

            _lines.AddRange(lines);
        }
        public enum OrderStatus
        {
            Open,
            Closed,
            Sent
        }
        public void CloseOrder()
        {
            if (Status != OrderStatus.Open)
            {
                throw new InvalidOperationException("Only open orders can be closed");
            }
            Status = OrderStatus.Closed;
        }
        public void AddOrderLine(int productId, int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.");
            }
            _lines.Add(new OrderLine(productId, quantity));
        }
    }
}
