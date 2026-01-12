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
        public DbSet<Product> Product => Set<Product>();
        public DbSet<Location> Location => Set<Location>();
        public DbSet<InventoryItem> InventoryItem => Set<InventoryItem>();
        public DbSet<ProductMovement> ProductMovement => Set<ProductMovement>();
        public DbSet<Order> Order => Set<Order>();
        public DbSet<OrderLine> OrderLine => Set<OrderLine>();
        public DbSet<User> User => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

    }
}