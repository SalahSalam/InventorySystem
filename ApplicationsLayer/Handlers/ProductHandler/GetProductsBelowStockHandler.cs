using ApplicationsLayer.DTO;
using ApplicationsLayer.Interfaces;
using InventorySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Handlers.ProductHandler
{
    public class GetProductsBelowMinimumStockHandler
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<InventoryItem> _inventoryRepo;

        public GetProductsBelowMinimumStockHandler(
            IGenericRepository<Product> productRepo,
            IGenericRepository<InventoryItem> inventoryRepo)
        {
            _productRepo = productRepo;
            _inventoryRepo = inventoryRepo;
        }

        public async Task<List<ProductDTO>> Handle()
        {
            var products = await _productRepo.GetAllAsync();
            var inventory = await _inventoryRepo.GetAllAsync();

            var result = new List<ProductDTO>();

            foreach (var product in products)
            {
                var totalQty = inventory
                    .Where(i => i.ProductId == product.ProductId)
                    .Sum(i => i.Quantity);

                if (product.IsBelowMinimum(totalQty))
                {
                    result.Add(new ProductDTO
                    {
                        ProductId = product.ProductId,
                        Name = product.Name,
                        Description = product.Description,
                        Category = product.Category ?? "",
                        Price = product.Price,
                        Minimumstock = product.Minimumstock
                    });
                }
            }
            return result;
        }
    }
}
