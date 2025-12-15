using Microsoft.VisualStudio.TestTools.UnitTesting;
using InventorySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Domain.Entities.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        // Verifies that SetMinimumStock sets the minimum stock value correctly.

        public void SetMinimumStock_ValidValue_SetsMinimumStock()
        {
            var product = new Product(1, "Test Product", "This is a test product.", "Test Category", 9.99m, 15);
            product.SetMinimumStock(10);
            Assert.IsTrue(product.IsBelowMinimum(9));
            Assert.IsFalse(product.IsBelowMinimum(10));
        }

        // Verifies that IsBelowMinimum returns true when current stock is below minimum.
        [TestMethod]
        public void IsBelowMinimum_CurrentStockBelowMinimum_ReturnsTrue()
        {
            var product = new Product(1, "Test Product", "This is a test product.", "Test Category", 9.99m, 15);
            product.SetMinimumStock(15);
            Assert.IsTrue(product.IsBelowMinimum(3));
        }

        // Verifies that IsBelowMinimum returns false when current stock is equal to or above minimum.
        [TestMethod]
        public void IsBelowMinimum_CurrentStockEqualOrAboveMinimum_ReturnsFalse()
        {
            var product = new Product(1, "Test Product", "This is a test product.", "Test Category", 9.99m, 15);
            product.SetMinimumStock(5);
            Assert.IsFalse(product.IsBelowMinimum(5));
            Assert.IsFalse(product.IsBelowMinimum(6));
        }

        // Verifies that setting a negative minimum stock throws an exception.
        [TestMethod]
        public void SetMinimumStock_NegativeValue_ThrowsException()
        {
            var product = new Product(1, "Test Product", "This is a test product.", "Test Category", 9.99m, 0);
            Assert.ThrowsException<ArgumentException>(() => product.SetMinimumStock(-1));
        }
        [TestMethod]
        public void SetMinimumStock_EqualZerp_ThrowsException()
        {
            var product = new Product(1, "Test Product", "This is a test product.", "Test Category", 9.99m, 0);
            Assert.ThrowsException<ArgumentException>(() => product.SetMinimumStock(0));
        }
    }
}