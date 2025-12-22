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
            var date = DateTime.Now;
            var item = new InventoryItem(1, 10, 5, 20, date);

            Assert.AreEqual(1, item.InventoryItemId);
            Assert.AreEqual(10, item.ProductId);
            Assert.AreEqual(5, item.LocationId);
            Assert.AreEqual(20, item.Quantity);
            Assert.AreEqual(date, item.LastUpdated);
        }


        [TestMethod()]
        // Checks that the constructor sets the quantity property correctly when initialized with a single parameter.
        public void InventoryitemTest_Correct()
        {
            {
                // Arrange
                int expectedQuantity = 0;

                // Act
                InventoryItem item = new InventoryItem(expectedQuantity);

                // Assert
                Assert.AreEqual(expectedQuantity, item.Quantity);
            }
        }

        [TestMethod]
        // Checks that the constructor sets the quantity property correctly when initialized with a single parameter.
        public void Constructor_ShouldSetQuantity_WhenSingleParameter()
        {
            // Arrange
            int expectedQuantity = 0;

            // Act
            InventoryItem item = new InventoryItem(expectedQuantity);

            // Assert
            Assert.AreEqual(expectedQuantity, item.Quantity);
        }

        [TestMethod()]
        // Verifies that the constructor sets the quantity property to the expected value.
        public void InventoryitemTest_Notcorrect()
        {
            {
                // Arrange
                int expectedQuantity = 0;
                int actualQuantity = -1;

                // Act
                InventoryItem item = new InventoryItem(expectedQuantity);

                // Assert
                Assert.AreEqual(expectedQuantity, item.Quantity);
            }
        }


        [TestMethod()]
        // Ensures UpdateQuantity throws an ArgumentException when a negative value is provided.
        public void UpdateQuantity_NegativeValue_ThrowsException()
        {
            // Arrange
            InventoryItem item = new InventoryItem(0);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => item.UpdateQuantity(-1));
        }

        [TestMethod()]
        // Verifies that UpdateQuantity correctly updates the quantity property when given a valid value.
        public void UpdateQuantityTest()
        {
            // Arrange
            int initialQuantity = 0;
            int updatedQuantity = 5;
            InventoryItem item = new InventoryItem(initialQuantity);

            // Act
            item.UpdateQuantity(updatedQuantity);

            // Assert
            Assert.AreEqual(updatedQuantity, item.Quantity);
        }

        [TestMethod()]
        // Ensures UpdateQuantity throws an ArgumentException when a negative value is provided (redundant test).
        public void UpdateQuantityTest_ThrowException()
        {
            // Arrange
            int initialQuantity = -1;
            int updatedQuantity = -1;
            InventoryItem item = new InventoryItem(initialQuantity);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => item.UpdateQuantity(updatedQuantity));
        }
    }
}