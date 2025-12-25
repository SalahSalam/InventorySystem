using ApplicationsLayer.Commands.Inventoryitem;
using ApplicationsLayer.Exeptions;
using ApplicationsLayer.Interfaces;
using InventorySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InventorySystem.Domain.Entities.ProductMovement;

namespace ApplicationsLayer.Handlers.InventoryitemHandler
{
    public class UpdateInventoryQuantityHandler
    {
        private readonly IGenericRepository<InventoryItem> _inventoryRepo;
        private readonly IGenericRepository<ProductMovement> _movementRepo;
        private readonly IGenericRepository<User> _userRepo;

        public UpdateInventoryQuantityHandler(
            IGenericRepository<InventoryItem> inventoryRepo,
            IGenericRepository<ProductMovement> movementRepo,
            IGenericRepository<User> userRepo)
        {
            _inventoryRepo = inventoryRepo;
            _movementRepo = movementRepo;
            _userRepo = userRepo;
        }

        public async Task Handle(UpdateInventoryQuantity x)
        {
            var item = await _inventoryRepo.GetByIdAsync(x.InventoryItemId)
                       ?? throw new NotFoundException($"InventoryItem {x.InventoryItemId} not found");

            var user = await _userRepo.GetByIdAsync(x.UserId)
                       ?? throw new NotFoundException($"User {x.UserId} not found");

            // Domain-method
            item.UpdateQuantity(x.QuantityChange);

            await _inventoryRepo.UpdateAsync(item);

            // Register movement in domain
            var movementType = x.QuantityChange >= 0 ? MovementType.In : MovementType.Out;

            var movement = new ProductMovement(
                productId: item.ProductId,
                fromLocationId: x.FromLocationId,
                toLocationId: x.ToLocationId,
                quantity: x.QuantityChange,
                type: movementType,
                userId: x.UserId,
                timestamp: DateTime.UtcNow
            );

            await _movementRepo.AddAsync(movement);
        }
    }
}
