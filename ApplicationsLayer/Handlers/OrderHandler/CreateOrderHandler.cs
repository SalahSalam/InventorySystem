using ApplicationsLayer.Commands.OrderCommands;
using ApplicationsLayer.Interfaces;
using InventorySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Handlers.OrderHandler
{
    public class CreateOrderHandler
    {
        private readonly IGenericRepository<Order> _repo;
        public CreateOrderHandler(IGenericRepository<Order> repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(CreateOrder x)
        {
            var order = new Order();
            await _repo.AddAsync(order);
            return order.OrderID;
        }

    }
}

