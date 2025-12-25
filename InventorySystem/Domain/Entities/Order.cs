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


        public Order(IEnumerable<(int productId, int quantity)> lines)
        {
            if (!lines.Any())
                throw new ArgumentException("An order must contain at least one order line.");

            CreatedAt = DateTime.UtcNow;
            Status = OrderStatus.Open;

            foreach (var (productId, quantity) in lines)
            {
                _lines.Add(new OrderLine(productId, quantity));
            }
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
    }
}
