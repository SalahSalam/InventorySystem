using Microsoft.VisualStudio.TestTools.UnitTesting;
using InventorySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InventorySystem.Domain.Entities.Order;

namespace InventorySystem.Domain.Entities.Tests
{
    [TestClass()]
    public class OrderTests
    {
        [TestMethod()]
        // Verifies that a new order is initialized with status Open, an empty orderlines list, and a valid CreatedAt date.    
        public void Constructor_ShouldInitializeOrderWithOpenStatusAndNonEmptyOrderlines()
        {
            // Arrange: Provide at least one valid order line to the constructor
            var order = new Order(new[] { (1, 1) });

            // Assert
            Assert.AreEqual(Order.OrderStatus.Open, order.Status);
            Assert.IsTrue(order.Lines.Count == 1);
            Assert.IsTrue(order.CreatedAt <= DateTime.Now);
        }

        [TestMethod()]
        // Verifies that adding an order line with a negative quantity throws an ArgumentException.    
        public void AddorderlineTest_InvalidQuantity_ThrowsException()
        {
            var order = new Order(new[] { (1, 1) });
            Assert.ThrowsException<ArgumentException>(() => order.AddOrderLine(1, -6));
        }

        [TestMethod()]
        // Verifies that adding an order line with quantity zero throws an ArgumentException.    
        public void AddorderlineTest_ZeroQuantity_ThrowsException()
        {
            var order = new Order(new[] { (1, 1) });
            Assert.ThrowsException<ArgumentException>(() => order.AddOrderLine(1, 0));
        }

        [TestMethod()]
        // Verifies that closing an already closed order throws an InvalidOperationException.    
        public void CloseOrder_AlreadyClosed_ThrowsException()
        {
            // Arrange: Provide at least one valid order line to the constructor
            var order = new Order(new[] { (1, 1) });
            order.CloseOrder();

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => order.CloseOrder());
        }

        [TestMethod]
        public void CloseOrder_WhenOrderIsNotOpen_ThrowsInvalidOperationException()
        {
            var order = new Order(new[] { (1, 2) });
            order.CloseOrder(); // Now status is Closed

            var ex = Assert.ThrowsException<InvalidOperationException>(() => order.CloseOrder());
            Assert.AreEqual("Only open orders can be closed", ex.Message);
        }
    }
}