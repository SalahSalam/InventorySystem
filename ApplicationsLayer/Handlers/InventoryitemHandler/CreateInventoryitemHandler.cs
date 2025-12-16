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
    public class CreateInventoryitemHandler
    {
        private readonly IGenericRepository<Inventoryitem> _repo;
        public CreateInventoryitemHandler(IGenericRepository<Inventoryitem> repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(CreateInventoryitem i)
        {
            var inventoryitem = new Inventoryitem
            (
                i.InventoryItemID,
                i.ProductID,
                i.LocationID,
                i.Quantity,
                DateTime.UtcNow,
                i.ExpectedQuantity
            );

            await _repo.AddAsync(inventoryitem);
            return inventoryitem.InventoryItemID;
        }

    }
}
