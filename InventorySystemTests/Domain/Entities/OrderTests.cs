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
        public void Constructor_ShouldInitializeOrderWithOpenStatusAndEmptyOrderlines()
        {
            var order = new Order();
            Assert.AreEqual(Order.OrderStatus.Open, order.Status);
            Assert.IsTrue(order._orderlines.Count == 0);
            Assert.IsTrue(order.CreatedAt <= DateTime.Now);
        }

        [TestMethod()]
        // Verifies that adding an order line with valid product ID and quantity correctly adds the order line to the order.
        public void AddorderlineTest_ValidInput_AddOrderLine()
        {
           var order = new Order();
           order.Addorderline(1, 2);
           Assert.AreEqual(1, order._orderlines.Count);
           Assert.AreEqual(1, order._orderlines[0].ProductID);
           Assert.AreEqual(2, order._orderlines[0].Quantity);
        }

        [TestMethod()]
        // Verifies that adding an order line with quantity zero throws an ArgumentException.
        public void AddorderlineTest_ZeroQuantity_ThrowsException()
        {
            var order = new Order();
            Assert.ThrowsException<ArgumentException>(() => order.Addorderline(1, 0));
        }

        [TestMethod()]
        // Verifies that adding an order line with a negative quantity throws an ArgumentException.
        public void AddorderlineTest_InvalidQuantity_ThrowsException()
        {
            var order = new Order();
            Assert.ThrowsException<ArgumentException>(() => order.Addorderline(1, -6)); 
        }

        // Verifies that closing an open order sets its status to Closed.
        [TestMethod()]
        public void CloseOrder_OpenOrder_ChangesStatusToClosed()
        {
            var order = new Order();
            order.CloseOrder();
            Assert.AreEqual(Order.OrderStatus.Closed, order.Status);
        }

        [TestMethod()]
        // Verifies that closing an already closed order throws an InvalidOperationException.
        public void CloseOrder_AlreadyClosed_ThrowsException()
        {
            var order = new Order();
            order.CloseOrder();
            Assert.ThrowsException<InvalidOperationException>(()=> order.CloseOrder());
        }

        [TestMethod()]
        // Verifies that closing an order with status Sent throws an InvalidOperationException.

        public void CloseOrder_sentOrder_ThrowsException() 
        {
            var order = new Order();
            order.Status = Order.OrderStatus.Sent;
            Assert.ThrowsException<InvalidOperationException>(() => order.CloseOrder());
        }
    }
}