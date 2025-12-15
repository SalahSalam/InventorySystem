using Applikationslag.Commands.ProductCommands;
using Applikationslag.Interfaces;
using Lagerstyring.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applikationslag.Handlers.ProductHandler
{
    public class DeleteProductHandler
    {
        private readonly IGenericRepository<Product> _repo;

        public DeleteProductHandler(IGenericRepository<Product> repo)
        {
            _repo = repo;
        }

        public async Task Handle(DeleteProduct x)
        {
            await _repo.DeleteAsync(x.ProductId);
        }
    }
}
