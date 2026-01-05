using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Commands.ProductCommands
{
    public class UpdateProductDetailsCommand
    {
        public int ProductId { get; }
        public string Name { get; }
        public string? Description { get; }
        public string Category { get; }
        public decimal Price { get; }
        public int MinimumStock { get; }

        public UpdateProductDetailsCommand(int productId, string name, string? description,
                                            string category, decimal price, int minimumStock)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            MinimumStock = minimumStock;
        }
    }
}
