using ApplicationsLayer.DTO;
using ApplicationsLayer.Interfaces;
using ApplicationsLayer.Queries.InventoryitemQuery;
using ApplicationsLayer.Queries.ProductMovementQuery;
using InventorySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Handlers.InventoryitemHandler
{
    internal class GetAllInventoryitemsHandler
    {
        private readonly IGenericRepository<Inventoryitem> _repo;

        public GetAllInventoryitemsHandler(IGenericRepository<Inventoryitem> repo)
        {
            _repo = repo;
        }

        public async Task<List<InventoryItemDTO>> Handle(GetAllInventoryitems query)
        {
            var inventoryitems = await _repo.GetAllAsync();

            return inventoryitems.Select(i => new InventoryItemDTO
            {
                InventoryItemID = i.InventoryItemID,
                ProductID = i.ProductID,
                LocationID = i.LocationID,
                Quantity = i.Quantity,
                ExpectedQuantity = i.ExpectedQuantity,
                LastUpdated = i.LastUpdated
            }).ToList();
        }
    }
}
