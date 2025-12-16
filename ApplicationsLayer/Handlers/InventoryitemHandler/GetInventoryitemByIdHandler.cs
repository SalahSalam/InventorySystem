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
    public class GetInventoryitemByIdHandler
    {
        private readonly IGenericRepository<Inventoryitem> _repo;
        public GetInventoryitemByIdHandler(IGenericRepository<Inventoryitem> repo)
        {
            _repo = repo;
        }
        public async Task<InventoryItemDTO> Handle(GetInventoryitemById query)
        {
            var inventoryitem = await _repo.GetByIdAsync(query.InventoryItemID);

            if (inventoryitem == null)
                return null; // or throw an exception, depending on your design

            return new InventoryItemDTO
            {
                InventoryItemID = inventoryitem.InventoryItemID,
                ProductID = inventoryitem.ProductID,
                LocationID = inventoryitem.LocationID,
                Quantity = inventoryitem.Quantity,
                ExpectedQuantity = inventoryitem.ExpectedQuantity,
                LastUpdated = inventoryitem.LastUpdated
            };
        }
    }
}