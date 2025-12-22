using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Domain.Entities
{
    public class OrderLine
    {
        private int _orderId; // set by Order / ORM
        private int _productId;
        private int _quantity;

        public int ProductId => _productId;
        public int Quantity => _quantity;

        public OrderLine(int productId, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            _productId = productId;
            _quantity = quantity;
        }

        // orderId is set internally
        internal void SetOrderId(int orderId)
        {
            _orderId = orderId;
        }
    }
}
