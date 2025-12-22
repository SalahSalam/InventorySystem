using ApplicationsLayer.Commands.ProductCommands;
using ApplicationsLayer.Interfaces;
using InventorySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Handlers.ProductHandler
{
    public class UpdateProductMinimumStockHandler
    {
        private readonly IGenericRepository<Product> _productRepo;

        public UpdateProductMinimumStockHandler(IGenericRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task Handle(UpdateProductMinimumStockCommand cmd)
        {
            var product = await _productRepo.GetByIdAsync(cmd.ProductId)
                ?? throw new Exception($"Product {cmd.ProductId} not found");

            product.SetMinimumStock(cmd.Minimumstock);

            await _productRepo.UpdateAsync(product);
        }
    }
}
