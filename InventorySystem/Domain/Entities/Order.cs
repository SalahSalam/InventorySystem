using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerstyring.Domain.Entities
{
    public class Order
    {
        public readonly List<Orderline> _orderlines = new List<Orderline>();
        public int OrderID { get; }
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }

        public enum OrderStatus
        {
            Open,
            Closed,
            Sent
        }

        public Order()
        {
            CreatedAt = DateTime.Now;
            Status = OrderStatus.Open;
        }
        public void Addorderline(int ProductID, int Quantity)
        {
            if (Quantity <= 0)
            {
                throw new ArgumentException("Quantity must be positive");
            }
            _orderlines.Add(new Orderline(OrderID, ProductID, Quantity));
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
