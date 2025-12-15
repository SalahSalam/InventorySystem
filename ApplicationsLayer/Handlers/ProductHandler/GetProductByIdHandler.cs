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
        private readonly IGenericRepository<Product> _repo;
        public GetProductByIdHandler(IGenericRepository<Product> repo)
        {
            _repo = repo;
        }
        public async Task<ProductDTO> Handle(GetProductById query)
        {
            var product = await _repo.GetByIdAsync(query.Productid);

            //if (product == null)
            //throw new NotFoundException(nameof(Product), query.Productid);

            return new ProductDTO
            {
                Productid = product.Productid,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Price = product.Price,
                Minimumstock = product.Minimumstock
            };
        }
    }
}

