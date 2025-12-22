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
    public class GetInventoryItemByIdHandler
    {
        private readonly IGenericRepository<InventoryItem> _inventoryRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<Location> _locationRepo;

        public GetInventoryItemByIdHandler(
            IGenericRepository<InventoryItem> inventoryRepo,
            IGenericRepository<Product> productRepo,
            IGenericRepository<Location> locationRepo)
        {
            _inventoryRepo = inventoryRepo;
            _productRepo = productRepo;
            _locationRepo = locationRepo;
        }

        public async Task<InventoryItemDTO> Handle(int inventoryItemId)
        {
            var item = await _inventoryRepo.GetByIdAsync(inventoryItemId)
                ?? throw new Exception("Inventory item not found.");

            var product = await _productRepo.GetByIdAsync(item.ProductId);
            var location = await _locationRepo.GetByIdAsync(item.LocationId);

            return new InventoryItemDTO
            {
                InventoryItemId = item.InventoryItemId,
                ProductId = item.ProductId,
                ProductName = product!.Name,
                LocationId = item.LocationId,
                LocationName = location!.Name,
                Quantity = item.Quantity,
                LastUpdated = item.LastUpdated
            };
        }
    }
}