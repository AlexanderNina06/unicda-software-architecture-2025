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
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(s => s.Id);

            #region Properties - Supplier Information

            builder.Property(s => s.CommercialName)
                .IsRequired()
                .HasMaxLength(200);

            // RNC: Dominican tax identification number (9-11 digits)
            builder.Property(s => s.RNC)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(s => s.Address)
                .HasMaxLength(300);

            builder.Property(s => s.Phone)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(100);

            #endregion

            #region Properties - Contact Information

            builder.Property(s => s.ContactName)
                .HasMaxLength(100);

            builder.Property(s => s.ContactPhone)
                .HasMaxLength(20);

            builder.Property(s => s.ContactEmail)
                .HasMaxLength(100);

            #endregion

            #region Properties - Additional

            builder.Property(s => s.Notes)
                .HasMaxLength(1000);

            builder.Property(s => s.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            #endregion

            #region Indexes

            // Unique constraint on RNC (business requirement)
            builder.HasIndex(s => s.RNC)
                .IsUnique();

            builder.HasIndex(s => s.CommercialName);

            #endregion
        }
    }
}
