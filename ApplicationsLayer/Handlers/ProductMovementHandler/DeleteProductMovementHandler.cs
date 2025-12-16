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
    public class DeleteProductMovementHandler
    {
        private readonly IGenericRepository<ProductMovement> _repo;

        public DeleteProductMovementHandler(IGenericRepository<ProductMovement> repo)
        {
            _repo = repo;
        }

        public async Task Handle(DeleteProductmovement x)
        {
            await _repo.DeleteAsync(x.Movementid);
        }
    }
}
