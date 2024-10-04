using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectAPP.Models;

namespace ProjectAPP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // category.cs will map to categories table

        public DbSet<Category> Categories { get; set; }

        // supplier.cs will map to suppliers table
        public DbSet<Supplier> Suppliers { get; set; }

        // item.cs will map to the items table
        public DbSet<Item> Items { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
