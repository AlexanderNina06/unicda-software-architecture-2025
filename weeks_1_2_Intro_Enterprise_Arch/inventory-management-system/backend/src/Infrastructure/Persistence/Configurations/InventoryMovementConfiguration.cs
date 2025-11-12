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
    public class InventoryMovementConfiguration : IEntityTypeConfiguration<InventoryMovement>
    {
        public void Configure(EntityTypeBuilder<InventoryMovement> builder)
        {
            builder.HasKey(im => im.Id);

            #region Properties

            builder.Property(im => im.Type)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(im => im.Quantity)
                .IsRequired();

            builder.Property(im => im.StockAfterMovement)
                .IsRequired();

            builder.Property(im => im.Reason)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(im => im.InvoiceNumber)
                .HasMaxLength(50);

            builder.Property(im => im.Destination)
                .HasMaxLength(200);

            builder.Property(im => im.Notes)
                .HasMaxLength(1000);

            builder.Property(im => im.MovementDate)
                .IsRequired();

            builder.Property(im => im.UserId)
                .IsRequired()
                .HasMaxLength(450);  // ASP.NET Identity UserId size

            #endregion

            #region Indexes

            builder.HasIndex(im => im.ProductId);

            builder.HasIndex(im => im.MovementDate);

            // Composite index for product movement history (common query)
            builder.HasIndex(im => new { im.ProductId, im.MovementDate });

            #endregion

            #region Relationships

            builder
                .HasOne(im => im.Product)
                .WithMany(p => p.InventoryMovements)
                .HasForeignKey(im => im.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion
        }
    }
}
