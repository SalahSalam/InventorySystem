using ApplicationsLayer.Commands.Inventoryitem;
using ApplicationsLayer.Commands.ProductMovementCommands;
using ApplicationsLayer.Interfaces;
using InventorySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Handlers.InventoryitemHandler
{
    public class DeleteInventoryitemHandler
    {
        private readonly IGenericRepository<Inventoryitem> _repo;

        public DeleteInventoryitemHandler(IGenericRepository<Inventoryitem> repo)
        {
            _repo = repo;
        }

        public async Task Handle(DeleteInventoryitem x)
        {
            await _repo.DeleteAsync(x.InventoryItemID);
        }
    }
}
