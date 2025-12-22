using ApplicationsLayer.DTO;
using ApplicationsLayer.Interfaces;
using InventorySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Handlers.ProductMovementHandler
{
    public class GetProductMovementsByDateRangeHandler
    {
        private readonly IGenericRepository<ProductMovement> _movementRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<User> _userRepo;

        public GetProductMovementsByDateRangeHandler(
            IGenericRepository<ProductMovement> movementRepo,
            IGenericRepository<Product> productRepo,
            IGenericRepository<User> userRepo)
        {
            _movementRepo = movementRepo;
            _productRepo = productRepo;
            _userRepo = userRepo;
        }

        public async Task<List<ProductMovementDTO>> Handle(DateTime from, DateTime to)
        {
            var movements = (await _movementRepo.GetAllAsync())
                .Where(m => m.Timestamp >= from && m.Timestamp <= to);

            var products = await _productRepo.GetAllAsync();
            var users = await _userRepo.GetAllAsync();

            return movements.Select(m => new ProductMovementDTO
            {
                Movementid = m.MovementId,
                Productid = m.ProductId,
                ProductName = products.First(p => p.ProductId == m.ProductId).Name,
                FromLocationId = m.FromLocationId,
                ToLocationId = m.ToLocationId,
                Userid = m.UserId,
                UserName = users.First(u => u.UserId == m.UserId).Name,
                Quantity = m.Quantity,
                Type = m.Type,
                Timestamp = m.Timestamp
            }).ToList();
        }
    }

}
