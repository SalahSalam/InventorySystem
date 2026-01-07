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
    public class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            // Composite key: shadow OrderId + domain ProductId
            builder.HasKey("OrderId", nameof(OrderLine.ProductId));

            // Shadow property (FK til Order)
            builder.Property<int>("OrderId")
                   .IsRequired();

            builder.Property(ol => ol.ProductId)
                   .IsRequired();

            builder.Property(ol => ol.Quantity)
                   .IsRequired();

            // Relation til Order via backing field
            builder.HasOne<Order>()
                   .WithMany("_lines")
                   .HasForeignKey("OrderId")
                   .IsRequired();
        }
    }
}