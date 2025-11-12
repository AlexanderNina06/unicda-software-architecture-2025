using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        DbSet<Product> Products { get; set;  }
        DbSet<Category> Categories { get; set; }
        DbSet<InventoryMovement> InventoryMovements { get; set; }
        DbSet<Supplier> Suppliers { get; set; }
        DbSet<Alert> Alerts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }

}
