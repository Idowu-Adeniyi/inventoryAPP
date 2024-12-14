using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectAPP.Models;

namespace ProjectAPP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // Map to Categories table
        public DbSet<Category> Categories { get; set; }

        // Map to Suppliers table
        public DbSet<Supplier> Suppliers { get; set; }

        // Map to Items table
        public DbSet<Item> Items { get; set; }

        // Explicitly map FitnessEquipment model to FitnessEquipments table
        public DbSet<FitnessEquipment> FitnessEquipments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Explicit table name mappings (optional)
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Supplier>().ToTable("Suppliers");
            builder.Entity<Item>().ToTable("Items");
            builder.Entity<FitnessEquipment>().ToTable("FitnessEquipments");
        }
    }
}
