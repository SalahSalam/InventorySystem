using ApplicationsLayer.DTO;
using ApplicationsLayer.Interfaces;
using ApplicationsLayer.Queries.ProductMovementQuery;
using ApplicationsLayer.Queries.ProductQuery;
using InventorySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Handlers.ProductMovementHandler
{
    public class GetProductMovementByIdHandler
    {
        private readonly IGenericRepository<ProductMovement> _repo;
        public GetProductMovementByIdHandler(IGenericRepository<ProductMovement> repo)
        {
            _repo = repo;
        }
        public async Task<ProductMovementDTO> Handle(GetProductMovementById query)
        {
            var produc = await _repo.GetByIdAsync(query.Movementid);

            //if (product == null)
            //throw new NotFoundException(nameof(Product), query.Productid);

            return new ProductMovementDTO
            {
                
            };

        }
    }
}