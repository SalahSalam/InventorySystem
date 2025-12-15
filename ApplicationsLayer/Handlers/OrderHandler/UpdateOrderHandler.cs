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
    public class UpdateOrderHandler
    {
        private readonly IGenericRepository<Order> _repo;
        public UpdateOrderHandler(IGenericRepository<Order> repo)
        {
            _repo = repo;
        }
        public async Task<bool> Handle(UpdateOrder x)
        {
            var order = await _repo.GetByIdAsync(x.OrderId);
            if (order == null)
                return false;


            await _repo.UpdateAsync(order);
            return true;
        }
    }
}
