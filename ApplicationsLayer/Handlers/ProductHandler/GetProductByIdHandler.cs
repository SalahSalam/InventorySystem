using ApplicationsLayer.DTO;
using ApplicationsLayer.Interfaces;
using ApplicationsLayer.Queries.ProductQuery;
using InventorySystem.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Handlers.ProductHandler
{
    public class GetProductByIdHandler
    {
        private readonly IGenericRepository<Product> _productRepo;

        public GetProductByIdHandler(IGenericRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<ProductDTO> Handle(GetProductById query)
        {
            var product = await _productRepo.GetByIdAsync(query.ProductId)
                ?? throw new Exception($"Product {query.ProductId} not found");

            return new ProductDTO
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category ?? "",
                Price = product.Price,
                Minimumstock = product.Minimumstock
            };
        }
    }

}

