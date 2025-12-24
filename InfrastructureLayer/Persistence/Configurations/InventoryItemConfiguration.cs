using InventorySystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Persistence.Configurations
{
    public class InventoryItemConfiguration : IEntityTypeConfiguration<InventoryItem>
    {
        public void Configure(EntityTypeBuilder<InventoryItem> builder)
        {
            builder.HasKey(i => i.InventoryItemId);

            builder.Property(i => i.Quantity).IsRequired();
            builder.Property(i => i.LastUpdated).IsRequired();

            builder.HasIndex(i => new { i.ProductId, i.LocationId })
                   .IsUnique();
            // Prevents two inventory rows for the same product at the same location
        }
    }

}
