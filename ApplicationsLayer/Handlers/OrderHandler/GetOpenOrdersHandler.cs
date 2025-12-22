using ApplicationsLayer.DTO;
using ApplicationsLayer.Interfaces;
using InventorySystem.Domain.Entities;
using ApplicationsLayer.Queries.OrderQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InventorySystem.Domain.Entities.Order;

namespace ApplicationsLayer.Handlers.OrderHandler
{
    public class GetOpenOrdersHandler
    {
        private readonly IGenericRepository<Order> _orderRepository;

        public GetOpenOrdersHandler(IGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderDTO>> Handle(GetOpenOrders q)
        {
            // get all orders
            var orders = await _orderRepository.GetAllAsync();

            // filter open orders
            var openOrders = orders
                .Where(o => o.Status == OrderStatus.Open)
                .Select(o => new OrderDTO
                {
                    OrderId = o.OrderId,
                    CreatedAt = o.CreatedAt,
                    Status = o.Status,
                    Lines = o.Lines.Select(ol => new OrderLineDTO
                    {
                        ProductId = ol.ProductId,
                        Quantity = ol.Quantity
                    }).ToList()
                })
                .ToList();

            return openOrders;
        }
    }
}
