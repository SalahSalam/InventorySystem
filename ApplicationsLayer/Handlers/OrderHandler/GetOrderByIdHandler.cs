using Applikationslag.DTO;
using Applikationslag.Interfaces;
using Applikationslag.Queries.OrderQuery;
using Lagerstyring.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applikationslag.Handlers.OrderHandler
{
    public class GetOrderByIdHandler
    {
        private readonly IGenericRepository<Order> _repo;

        public GetOrderByIdHandler(IGenericRepository<Order> repo)
        {
            _repo = repo;
        }

        public async Task<OrderDTO?> Handle(GetOrderById q)
        {
            var o = await _repo.GetByIdAsync(q.OrderId);
            if (o == null)
                return null;

            return new OrderDTO
            {
                OrderID = o.OrderID,
                CreatedAt = o.CreatedAt
            };
        }
    }
}
