using ApplicationsLayer.Commands.OrderCommands;
using ApplicationsLayer.Exeptions;
using ApplicationsLayer.Interfaces;
using InventorySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InventorySystem.Domain.Entities.Order;

namespace ApplicationsLayer.Handlers.OrderHandler
{
    public class CreateOrderHandler
    {
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<Product> _productRepo;

        public CreateOrderHandler(
            IGenericRepository<Order> orderRepo,
            IGenericRepository<Product> productRepo)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
        }

        public async Task<int> Handle(CreateOrder x)
        {
            if (x.Lines == null || x.Lines.Count == 0)
                throw new DomainValidationException("Order must contain at least one line.");

            var lineData = new List<(int productId, int quantity)>();

            foreach (var line in x.Lines)
            {
                var product = await _productRepo.GetByIdAsync(line.ProductId);
                if (product == null)
                    throw new NotFoundException($"Product {line.ProductId} not found.");

                lineData.Add((line.ProductId, line.Quantity));
            }

            var order = new Order(lineData);
            await _orderRepo.AddAsync(order);
            return order.OrderId;
        }
    }
}

