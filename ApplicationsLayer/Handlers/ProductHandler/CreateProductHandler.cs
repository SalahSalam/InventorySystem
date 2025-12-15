using Applikationslag.Commands.ProductCommands;
using Applikationslag.Interfaces;
using Lagerstyring.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Applikationslag.Handlers.ProductHandler
{
    public class CreateProductHandler
    {
        private readonly IGenericRepository<Product> _repo;
        public CreateProductHandler(IGenericRepository<Product> repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(CreateProduct x)
        {
            var product = new Product(x.Productid, x.Name, x.Description, x.Category, x.Price, x.Minimumstock);
            await _repo.AddAsync(product);
            return product.Productid;
        }
    }
}
