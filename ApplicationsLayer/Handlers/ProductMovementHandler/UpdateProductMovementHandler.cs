using ApplicationsLayer.Commands.ProductMovementCommands;
using ApplicationsLayer.Commands.ProductCommands;
using ApplicationsLayer.Interfaces;
using InventorySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Handlers.ProductMovementHandler
{
    public class UpdateProductMovementHandler
    {
        private readonly IGenericRepository<ProductMovement> _repo;

        public UpdateProductMovementHandler(IGenericRepository<ProductMovement> repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(UpdateProductMovement x)
        {
            var productMovement = await _repo.GetByIdAsync(x.Movementid);
            if (productMovement == null)
                return false;


            await _repo.UpdateAsync(productMovement);
            return true;
        }

    }
}
