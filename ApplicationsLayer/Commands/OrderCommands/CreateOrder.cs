using ApplicationsLayer.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Commands.OrderCommands
{
    public class CreateOrder
    {
        public IReadOnlyList<CreateOrderLine> Lines { get; }

        public CreateOrder(IEnumerable<CreateOrderLine> lines)
        {
            Lines = lines?.ToList()
                ?? throw new DomainValidationException("Order must contain at least one order line.");

            if (!Lines.Any())
                throw new DomainValidationException("Order must contain at least one order line.");
        }
    }
    public class CreateOrderLine
    {
        public int ProductId { get; }
        public int Quantity { get; }
        public CreateOrderLine(int productId, int quantity)
        {
            if (productId <= 0)
                throw new DomainValidationException("Invalid product id.");

            if (quantity <= 0)
                throw new DomainValidationException("Quantity must be greater than zero.");

            ProductId = productId;
            Quantity = quantity;
        }
    }
}
