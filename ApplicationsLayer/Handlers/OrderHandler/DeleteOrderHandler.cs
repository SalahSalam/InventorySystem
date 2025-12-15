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
    public class DeleteOrderHandler
    {
        private readonly IGenericRepository<Order> _repo;

        public DeleteOrderHandler(IGenericRepository<Order> repo)
        {
            _repo = repo;
        }

        public async Task Handle(DeleteOrder x)
        {
            await _repo.DeleteAsync(x.OrderId);
        }
    }
}
