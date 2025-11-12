using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            #region Properties - Basic Information

            builder.Property(p => p.Sku)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Description)
                .HasMaxLength(1000);

            #endregion

            #region Properties - Inventory

            builder.Property(p => p.CurrentStock)
                .IsRequired();

            builder.Property(p => p.MinimumStock)
                .IsRequired();

            builder.Property(p => p.MaximumStock);

            builder.Property(p => p.StorageLocation)
                .HasMaxLength(50);

            #endregion

            #region Properties - Pricing

            builder.Property(p => p.CostPrice)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(p => p.SalePrice)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(p => p.Currency)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(3); 

            #endregion

            #region Properties - Additional Information

            builder.Property(p => p.ImageUrl)
                .HasMaxLength(500); 

            builder.Property(p => p.Barcode)
                .HasMaxLength(13);  // 8-13 digits

            builder.Property(p => p.IsPerishable)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(p => p.ExpirationDate);

            builder.Property(p => p.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            #endregion

            #region Indexes

            // Unique constraint on SKU (business requirement)
            builder.HasIndex(p => p.Sku)
                .IsUnique();

            builder.HasIndex(p => p.Name);

            builder.HasIndex(p => p.CategoryId);

            builder.HasIndex(p => p.SupplierId);

            // Composite index for active products by category (common query)
            builder.HasIndex(p => new { p.CategoryId, p.IsActive });

            #endregion

            #region Relationships

            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
        }
    }
}
