using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Domain.Entities
{
    public class Location
    {
        public int LocationId { get; }
        public string Name { get; private set; }
        public string? Description { get; private set; }

        public Location(string name, string? description)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(name);

            Name = name;
            Description = description;
        }
    }
}
