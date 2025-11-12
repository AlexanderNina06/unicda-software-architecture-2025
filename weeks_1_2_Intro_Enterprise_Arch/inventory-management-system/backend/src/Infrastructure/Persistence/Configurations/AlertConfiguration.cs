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
    public class AlertConfiguration : IEntityTypeConfiguration<Alert>
    {
        public void Configure(EntityTypeBuilder<Alert> builder)
        {
            builder.HasKey(a => a.Id);

            #region Properties

            builder.Property(a => a.Type)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(a => a.Message)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(a => a.IsViewed)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(a => a.IsResolved)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(a => a.ResolvedBy)
                .HasMaxLength(450);  // ASP.NET Identity UserId size

            #endregion

            #region Indexes

            builder.HasIndex(a => a.ProductId);

            // Composite index for active alerts by product
            builder.HasIndex(a => new { a.ProductId, a.IsResolved });

            // Filtered index for active alerts only (most common query)
            builder.HasIndex(a => new { a.IsResolved, a.Created })
                .HasFilter("[IsResolved] = 0");

            #endregion

            #region Relationships

            builder
                .HasOne(a => a.Product)
                .WithMany(p => p.Alerts)
                .HasForeignKey(a => a.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion
        }
    }
}
