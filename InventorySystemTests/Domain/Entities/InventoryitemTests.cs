using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lagerstyring.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerstyring.Domain.Entities.Tests
{
    [TestClass()]
    public class InventoryitemTests
    {
        [TestMethod()]
        // Verifies that the constructor initializes all properties correctly with valid input.
        public void Constructor_ShouldInitializeValues_WhenValidInput()
        {
            var date = DateTime.Now;
            var item = new Inventoryitem(1, 10, 5, 20, date);

            Assert.AreEqual(1, item.InventoryItemID);
            Assert.AreEqual(10, item.ProductID);
            Assert.AreEqual(5, item.LocationID);
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
                Inventoryitem item = new Inventoryitem(expectedQuantity);

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
            Inventoryitem item = new Inventoryitem(expectedQuantity);

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
                Inventoryitem item = new Inventoryitem(expectedQuantity);

                // Assert
                Assert.AreEqual(expectedQuantity, item.Quantity);
            }
        }


        [TestMethod()]
        // Ensures UpdateQuantity throws an ArgumentException when a negative value is provided.
        public void UpdateQuantity_NegativeValue_ThrowsException()
        {
            // Arrange
            Inventoryitem item = new Inventoryitem(0);

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
            Inventoryitem item = new Inventoryitem(initialQuantity);

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
            Inventoryitem item = new Inventoryitem(initialQuantity);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => item.UpdateQuantity(updatedQuantity));
        }
    }
}