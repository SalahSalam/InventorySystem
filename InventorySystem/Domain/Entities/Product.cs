using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Domain.Entities
{
    public class Product
    {
        public int Productid { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Minimumstock { get; set; }
        public Product(int productid, string name, string description, string category, decimal price, int minimumstock)
        {
            Productid = productid;
            Name = name;
            Description = description;
            Category = category;
            Price = price;

            if (minimumstock < 0)
            {
                throw new ArgumentException("Minimum stock cannot be negative.");
            }
            Minimumstock = minimumstock;
        }
        //	IsBelowMinimum helps you check if you need to reorder or restock a product.
        public bool IsBelowMinimum(int currentStock)
        {
            return currentStock < Minimumstock;
        }
        //	SetMinimumStock lets you adjust the threshold for when a product is considered low in stock.
        public void SetMinimumStock(int value)
        {
            if (value <= 0)
                throw new ArgumentException("Minimum stock cannot be negative.");
            Minimumstock = value;
        }
    }
}
