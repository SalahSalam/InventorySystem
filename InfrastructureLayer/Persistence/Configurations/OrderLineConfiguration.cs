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
            // Define shadow properties first
            builder.Property<int>("_orderId")
                   .HasColumnName("OrderId");

            builder.Property<int>("_productId")
                   .HasColumnName("ProductId");

            builder.Property<int>("_quantity")
                   .HasColumnName("Quantity")
                   .IsRequired();

            // Set composite key using shadow properties
            builder.HasKey("_orderId", "_productId");
        }
    }
}