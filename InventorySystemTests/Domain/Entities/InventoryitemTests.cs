using Microsoft.VisualStudio.TestTools.UnitTesting;
using InventorySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Domain.Entities.Tests
{
    [TestClass()]
    public class InventoryitemTests
    {
        [TestMethod()]
        // Verifies that the constructor initializes all properties correctly with valid input.
        public void Constructor_ShouldInitializeValues_WhenValidInput()
        {
            // Arrange
            int inventoryItemId = 1;
            int productId = 10;
            int locationId = 5;
            int quantity = 20;
            DateTime lastUpdated = DateTime.Now;

            // Act
            var item = new InventoryItem(inventoryItemId, productId, locationId, quantity, lastUpdated); // 0 for expectedQuantity

            // Assert
            Assert.AreEqual(inventoryItemId, item.InventoryItemId);
            Assert.AreEqual(productId, item.ProductId);
            Assert.AreEqual(locationId, item.LocationId);
            Assert.AreEqual(quantity, item.Quantity);
            Assert.AreEqual(lastUpdated, item.LastUpdated);
        }

            [TestMethod]
        // Checks that the constructor sets the quantity property correctly when initialized with a single parameter.
        // Checks that the constructor sets the quantity property correctly when initialized with all required parameters.
        public void Constructor_ShouldSetQuantity_WhenAllParametersProvided()
        {
            // Arrange
            int inventoryItemId = 1;
            int productId = 10;
            int locationId = 5;
            int quantity = 0;
            DateTime lastUpdated = DateTime.Now;

            // Act
            InventoryItem item = new InventoryItem(inventoryItemId, productId, locationId, quantity, lastUpdated);

            // Assert
            Assert.AreEqual(quantity, item.Quantity);
        }

        //[TestMethod()]
        //// Verifies that the constructor sets the quantity property to the expected value.
        //public void InventoryitemTest_Notcorrect()
        //{
        //    // Arrange
        //    int inventoryItemId = 1;
        //    int productId = 10;
        //    int locationId = 5;
        //    int quantity = 0;
        //    DateTime lastUpdated = DateTime.Now;
        //    //int expectedQuantity = 0;

        //    // Act
        //    InventoryItem item = new InventoryItem(inventoryItemId, productId, locationId, quantity, lastUpdated, expectedQuantity);

        //    // Assert
        //    Assert.AreEqual(expectedQuantity, item.Quantity);
        //}


        [TestMethod()]
        // Ensures UpdateQuantity throws an ArgumentException when a negative value is provided.
        public void UpdateQuantity_NegativeValue_ThrowsException()
        {
            // Arrange
            int inventoryItemId = 1;
            int productId = 10;
            int locationId = 5;
            int quantity = 0;
            DateTime lastUpdated = DateTime.Now;
            //int expectedQuantity = 0;

            InventoryItem item = new InventoryItem(inventoryItemId, productId, locationId, quantity, lastUpdated);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => item.UpdateQuantity(-1));
        }

        [TestMethod()]
        // Verifies that UpdateQuantity correctly updates the quantity property when given a valid value.
        public void UpdateQuantityTest()
        {
            // Arrange
            int inventoryItemId = 1;
            int productId = 10;
            int locationId = 5;
            int initialQuantity = 0;
            DateTime lastUpdated = DateTime.Now;
            int expectedQuantity = 5;

            InventoryItem item = new InventoryItem(inventoryItemId, productId, locationId, initialQuantity, lastUpdated);

            // Act
            item.UpdateQuantity(expectedQuantity);

            // Assert
            Assert.AreEqual(expectedQuantity, item.Quantity);
        }

        [TestMethod()]
        // Ensures UpdateQuantity throws an ArgumentException when a negative value is provided (redundant test).
        public void UpdateQuantityTest_ThrowException()
        {
            // Arrange
            int inventoryItemId = 1;
            int productId = 10;
            int locationId = 5;
            int initialQuantity = 0; // Fixed: must be non-negative
            DateTime lastUpdated = DateTime.Now;

            InventoryItem item = new InventoryItem(inventoryItemId, productId, locationId, initialQuantity, lastUpdated);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => item.UpdateQuantity(-1));
        }
    }
}