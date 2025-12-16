using ApplicationsLayer.DTO;
using ApplicationsLayer.Interfaces;
using ApplicationsLayer.Queries.ProductMovementQuery;
using InventorySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApplicationsLayer.Queries.ProductQuery.GetAllProducts;
using static InventorySystem.Domain.Entities.ProductMovement;

namespace ApplicationsLayer.Handlers.ProductMovementHandler
{
    public class GetAllProductsMovementHandler
    {
        private readonly IGenericRepository<ProductMovement> _repo;

        public GetAllProductsMovementHandler(IGenericRepository<ProductMovement> repo)
        {
            _repo = repo;
        }

        public async Task<List<ProductMovementDTO>> Handle(GetAllProductMovements query)
        {
            var productMovement = await _repo.GetAllAsync();

            return productMovement.Select(m => new ProductMovementDTO
            {
                Movementid = m.Movementid,
                Productid = m.Productid,
                Userid = m.Userid,
                Quantity = m.Quantity,
                Type = m.Type,
                Timestamp = m.Timestamp

            }).ToList();
        }
    }
}
