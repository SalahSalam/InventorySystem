using ApplicationsLayer.DTO;
using ApplicationsLayer.Interfaces;
using InventorySystem.Domain.Entities;
using ApplicationsLayer.Queries.ProductQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Handlers.ProductHandler
{
    public class GetAllProductsHandler
    {
        private readonly IGenericRepository<Product> _productRepo;

        public GetAllProductsHandler(IGenericRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<List<ProductDTO>> Handle(GetAllProducts query)
        {
            var products = await _productRepo.GetAllAsync();

            return products.Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description ?? "",
                Category = p.Category ?? "",
                Price = p.Price,
                Minimumstock = p.Minimumstock
            }).ToList();
        }
    }

}
