using ApplicationsLayer.Commands.ProductCommands;
using ApplicationsLayer.Interfaces;
using InventorySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationsLayer.Exeptions;

namespace ApplicationsLayer.Handlers.ProductHandler
{
    public class UpdateProductDetailsHandler
    {
        private readonly IGenericRepository<Product> _productRepo;

        public UpdateProductDetailsHandler(IGenericRepository<Product> repo)
        {
            _productRepo = repo;
        }

        public async Task Handle(UpdateProductDetailsCommand x)
        {
            var product = await _productRepo.GetByIdAsync(x.Productid);
            if (product == null)
                throw new ArgumentException($"Product with id {x.Productid} not found.");

            product.UpdateDetails(x.Name, x.Description, x.Category, x.Price);

            await _productRepo.UpdateAsync(product);
        }
    }
}