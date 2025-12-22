using ApplicationsLayer.Exeptions;
using ApplicationsLayer.Interfaces;
using InventorySystem.Domain.Entities;
using ApplicationsLayer.Commands.OrderCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Handlers.OrderHandler
{
    public class CloseOrderHandler
    {
        private readonly IGenericRepository<Order> _orderRepository;

        public CloseOrderHandler(IGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(CloseOrder c)
        {
            // getting order
            var order = await _orderRepository.GetByIdAsync(c.OrderId);

            if (order == null)
                throw new NotFoundException(
                    $"Order with id {c.OrderId} was not found.");

            // domain decides if operation is legal
            order.CloseOrder();

            // persist change
            await _orderRepository.UpdateAsync(order);
        }
    }
}
