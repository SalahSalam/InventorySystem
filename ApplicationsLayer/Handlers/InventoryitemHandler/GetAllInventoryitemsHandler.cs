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
    public class GetAllInventoryItemsHandler
    {
        private readonly IGenericRepository<InventoryItem> _inventoryRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<Location> _locationRepo;

        public GetAllInventoryItemsHandler(
            IGenericRepository<InventoryItem> inventoryRepo,
            IGenericRepository<Product> productRepo,
            IGenericRepository<Location> locationRepo)
        {
            _inventoryRepo = inventoryRepo;
            _productRepo = productRepo;
            _locationRepo = locationRepo;
        }

        public async Task<List<InventoryItemDTO>> Handle()
        {
            var items = await _inventoryRepo.GetAllAsync();
            var products = await _productRepo.GetAllAsync();
            var locations = await _locationRepo.GetAllAsync();

            return items.Select(i => new InventoryItemDTO
            {
                InventoryItemId = i.InventoryItemId,
                ProductId = i.ProductId,
                ProductName = products.First(p => p.ProductId == i.ProductId).Name,
                LocationId = i.LocationId,
                LocationName = locations.First(l => l.LocationId == i.LocationId).Name,
                Quantity = i.Quantity,
                LastUpdated = i.LastUpdated
            }).ToList();
        }
    }
}
