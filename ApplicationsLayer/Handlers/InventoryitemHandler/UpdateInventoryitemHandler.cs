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
    public class UpdateInventoryitemHandler
    {
        private readonly IGenericRepository<Inventoryitem> _repo;

        public UpdateInventoryitemHandler(IGenericRepository<Inventoryitem> repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(UpdateInventoryitem x)
        {
            var inventoryitem = await _repo.GetByIdAsync(x.InventoryItemID);
            if (inventoryitem == null)
                return false;


            await _repo.UpdateAsync(inventoryitem);
            return true;
        }

    }
}
