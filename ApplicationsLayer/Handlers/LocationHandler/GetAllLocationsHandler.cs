using ApplicationsLayer.DTO;
using ApplicationsLayer.Interfaces;
using InventorySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsLayer.Handlers.LocationHandler
{
    public class GetAllLocationsHandler
    {
        private readonly IGenericRepository<Location> _locationRepository;

        public GetAllLocationsHandler(IGenericRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<List<LocationDTO>> Handle()
        {
            // get domain-entities
            var locations = await _locationRepository.GetAllAsync();

            // map to DTO
            return locations.Select(l => new LocationDTO
            {
                LocationId = l.LocationId,
                Name = l.Name,
                Description = l.Description
            }).ToList();
        }
    }
}
