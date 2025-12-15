using ApplicationsLayer.Commands.ProductmovementCommands;
using ApplicationsLayer.Commands.OrderCommands;
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
    internal class CreateProductMovementHandler
    {
        private readonly IGenericRepository<ProductMovement> _repo;
        public CreateProductMovementHandler(IGenericRepository<ProductMovement> repo)
        {
            _repo = repo;
        } 

        public async Task<int> Handle(CreateProductMovement x)
        {
            var productMovement = new ProductMovement(
                x.ProductId,
                x.UserId,
                x.Quantity,
                x.Type,
                DateTime.UtcNow  
            );

            await _repo.AddAsync(productMovement);
            return productMovement.Movementid;
        }

    }
}

