using ApplicationsLayer.Interfaces;
using InventorySystem.Domain.Entities;
using ApplicationsLayer.Commands.LocationCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Handlers.LocationHandler
{
    public class CreateLocationHandler
    {
        private readonly IGenericRepository<Location> _locationRepository;

        public CreateLocationHandler(IGenericRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<int> Handle(CreateLocation c)
        {
            var location = new Location(
                c.Name,
                c.Description
            );

            await _locationRepository.AddAsync(location);

            return location.LocationId;
        }
    }
}
