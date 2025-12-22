using ApplicationsLayer.DTO;
using ApplicationsLayer.Interfaces;
using InventorySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Handlers.InventoryItemHandler
{
    public class GetInventoryByLocationHandler
    {
        private readonly IGenericRepository<InventoryItem> _inventoryRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<Location> _locationRepo;

        public GetInventoryByLocationHandler(
            IGenericRepository<InventoryItem> inventoryRepo,
            IGenericRepository<Product> productRepo,
            IGenericRepository<Location> locationRepo)
        {
            _inventoryRepo = inventoryRepo;
            _productRepo = productRepo;
            _locationRepo = locationRepo;
        }

        public async Task<List<InventoryItemDTO>> Handle(int locationId)
        {
            var items = await _inventoryRepo.GetAllAsync();
            var products = await _productRepo.GetAllAsync();
            var location = await _locationRepo.GetByIdAsync(locationId)
                ?? throw new Exception("Location not found.");

            return items
                .Where(i => i.LocationId == locationId)
                .Select(i => new InventoryItemDTO
                {
                    InventoryItemId = i.InventoryItemId,
                    ProductId = i.ProductId,
                    ProductName = products.First(p => p.ProductId == i.ProductId).Name,
                    LocationId = locationId,
                    LocationName = location.Name,
                    Quantity = i.Quantity,
                    LastUpdated = i.LastUpdated
                }).ToList();
        }
    }
}
