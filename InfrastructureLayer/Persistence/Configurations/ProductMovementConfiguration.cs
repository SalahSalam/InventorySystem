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
    public class ProductMovementConfiguration : IEntityTypeConfiguration<ProductMovement>
    {
        public void Configure(EntityTypeBuilder<ProductMovement> builder)
        {
            builder.HasKey(pm => pm.MovementId);

            builder.Property(pm => pm.Type)
                   .HasConversion<string>()
                   .IsRequired();

            builder.Property(pm => pm.Timestamp)
                   .IsRequired();

            builder.HasOne<Location>()
                   .WithMany()
                   .HasForeignKey(pm => pm.FromLocationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Location>()
                   .WithMany()
                   .HasForeignKey(pm => pm.ToLocationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Product>()
                   .WithMany()
                   .HasForeignKey(pm => pm.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(pm => pm.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            // DeleteBehavior gælder kun for hvis den anden tabel slettes?
        }
    }

}
