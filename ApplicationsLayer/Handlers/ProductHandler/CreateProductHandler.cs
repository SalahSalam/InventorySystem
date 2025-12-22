using ApplicationsLayer.Commands.ProductCommands;
using ApplicationsLayer.Interfaces;
using InventorySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApplicationsLayer.Handlers.ProductHandler
{
    public class CreateProductHandler
    {
        private readonly IGenericRepository<Product> _productRepo;
        public CreateProductHandler(IGenericRepository<Product> repo)
        {
            _productRepo = repo;
        }

        public async Task<int> Handle(CreateProductCommand x)
        {
            var product = new Product(x.Name, x.Description ?? null, x.Category ?? null, x.Price, x.Minimumstock);

            await _productRepo.AddAsync(product);
            return product.ProductId;
        }
    }
}
