using InventorySystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
namespace InfrastructureLayer.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();
        public DbSet<ProductMovement> ProductMovements => Set<ProductMovement>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderLine> OrderLines => Set<OrderLine>();
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            // Configure Order entity to use a factory for instantiation
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.OrderId);

                // Use a custom constructor for the Order entity
                entity.HasData(new Order(new List<(int productId, int quantity)>()));
            });

            // Add other entity configurations as needed
        }

    }
}