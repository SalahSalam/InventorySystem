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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderId);

            builder.Property(o => o.Status)
                   .HasConversion<string>();

            builder.Property(o => o.CreatedAt)
                   .IsRequired();

            builder.Ignore(o => o.Lines);

            builder.HasMany<OrderLine>("_lines")
               .WithOne()
               .HasForeignKey("OrderId")
               .IsRequired();

            builder.Navigation("_lines")
                   .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }

}
