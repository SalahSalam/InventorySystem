using Applikationslag.DTO;
using Applikationslag.Interfaces;
using Lagerstyring.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Applikationslag.Queries.ProductQuery.GetAllProducts;

namespace Applikationslag.Handlers.ProductHandler
{
    public class GetAllProductsHandler
    {
        private readonly IGenericRepository<Product> _repo;

        public GetAllProductsHandler(IGenericRepository<Product> repo)
        {
            _repo = repo;
        }

        public async Task<List<ProductDTO>> Handle(GetAllProductsQuery query)
        {
            var products = await _repo.GetAllAsync();

            return products.Select(p => new ProductDTO
            {
                Productid = p.Productid,
                Name = p.Name,
                Description = p.Description,
                Category = p.Category,
                Price = p.Price,
                Minimumstock = p.Minimumstock
            }).ToList();
        }
    }
}
