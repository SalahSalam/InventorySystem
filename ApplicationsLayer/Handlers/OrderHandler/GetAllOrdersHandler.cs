using ApplicationsLayer.DTO;
using ApplicationsLayer.Interfaces;
using ApplicationsLayer.Queries.OrderQuery;
using InventorySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Handlers.OrderHandler
{
    public class GetAllOrdersHandler
    {
        private readonly IGenericRepository<Order> _repo;

        public GetAllOrdersHandler(IGenericRepository<Order> repo)
        {
            _repo = repo;
        }

        public async Task<List<OrderDTO>> Handle(GetAllOrders q)
        {
            var orders = await _repo.GetAllAsync();
            return orders.Select(o => new OrderDTO
            {
                OrderId = o.OrderId,
                CreatedAt = o.CreatedAt
            }).ToList();
        }
    }
}
