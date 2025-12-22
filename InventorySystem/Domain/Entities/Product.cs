using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Domain.Entities
{
    public class Product
    {
        //PRIVATE FIELDS
        //prevents other parts of the system from changing values directly
        private string _name;
        private string? _description;
        private string? _category;
        private decimal _price;
        private int _minimumstock;

        //READ-ONLY PROPERTIES
        //Exposes data, but doesn't allow external code to modify it directly
        public int ProductId { get; private set; }
        public string Name => _name;
        public string? Description => _description;
        public string? Category => _category;
        public decimal Price => _price;
        public int Minimumstock => _minimumstock;

        //read-only to protect encapsulation
        private readonly List<InventoryItem> _inventoryItems = new();
        public IReadOnlyCollection<InventoryItem> InventoryItems => _inventoryItems.AsReadOnly();

        public Product(string name, string? description, string? category, decimal price, int minimumstock)
        {
            _name = name;
            _description = description;
            _category = category;
            _price = price;

            if (minimumstock < 0)
            {
                throw new ArgumentException("Minimum stock cannot be negative.");
            }
            _minimumstock = minimumstock;
        }
        //	IsBelowMinimum helps check if you need to reorder or restock a product.
        public bool IsBelowMinimum(int currentStock)
        {
            return currentStock < Minimumstock;
        }
        //	SetMinimumStock lets you adjust the threshold for when a product is considered low in stock.
        public void SetMinimumStock(int value)
        {
            if (value <= 0)
                throw new ArgumentException("Minimum stock cannot be negative.");
            _minimumstock = value;
        }

        public void UpdateDetails(string name, string? description, string? category, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Product name cannot be empty.");

            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentNullException("Category is required.");

            if (price < 0)
                throw new ArgumentException("Price cannot be negative.");

            _name = name;
            _description = description;
            _category = category;
            _price = price;
        }
    }
}
