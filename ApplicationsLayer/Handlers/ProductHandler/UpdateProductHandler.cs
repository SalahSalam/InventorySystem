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
    public class UpdateProductHandler
    {
        private readonly IGenericRepository<Product> _repo;

        public UpdateProductHandler(IGenericRepository<Product> repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(UpdateProduct x)
        {
            var product = await _repo.GetByIdAsync(x.Productid);
            if (product == null)
                return false;


            await _repo.UpdateAsync(product);
            return true;
        }

    }
}