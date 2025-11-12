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

            #region Properties - Información Básica

            builder.Property(p => p.Sku)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Description)
                .HasMaxLength(1000);

            #endregion

            #region Properties - Inventario

            builder.Property(p => p.CurrentStock)
                .IsRequired();

            builder.Property(p => p.MinimumStock)
                .IsRequired();

            builder.Property(p => p.MaximumStock);  // Opcional

            // Ubicación en almacén - OPCIONAL (ej: "Pasillo A, Estante 3, Nivel 2")
            builder.Property(p => p.StorageLocation)
                .HasMaxLength(50);

            #endregion

            #region Properties - Precios

            // Precio de Costo - REQUERIDO, mayor a 0
            builder.Property(p => p.CostPrice)
                .IsRequired()
                .HasPrecision(18, 2);  // 2 decimales según documento

            // Precio de Venta - REQUERIDO, >= precio costo (validación en FluentValidation)
            builder.Property(p => p.SalePrice)
                .IsRequired()
                .HasPrecision(18, 2);

            // Moneda - REQUERIDO (DOP o USD)
            builder.Property(p => p.Currency)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(3);  // "DOP" o "USD"

            #endregion

            #region Properties - Información Adicional

            // Imagen - OPCIONAL (Azure Blob Storage URL)
            // Formatos: JPG, PNG, máx 2MB (validación en servicio)
            builder.Property(p => p.ImageUrl)
                .HasMaxLength(500);

            // Código de Barras - OPCIONAL, 8-13 dígitos
            builder.Property(p => p.Barcode)
                .HasMaxLength(13);

            // Productos perecederos
            builder.Property(p => p.IsPerishable)
                .IsRequired()
                .HasDefaultValue(false);

            // Fecha de vencimiento - OPCIONAL (solo para perecederos)
            builder.Property(p => p.ExpirationDate);

            // Estado - REQUERIDO
            builder.Property(p => p.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            #endregion

            #region Indexes

            // SKU único (requisito del documento)
            builder.HasIndex(p => p.Sku)
                .IsUnique();

            // Nombre para búsquedas
            builder.HasIndex(p => p.Name);

            // Código de barras para búsquedas (puede repetirse, no único)
            builder.HasIndex(p => p.Barcode);

            // CategoryId para filtros
            builder.HasIndex(p => p.CategoryId);

            // SupplierId para filtros
            builder.HasIndex(p => p.SupplierId);

            // IsActive para filtros
            builder.HasIndex(p => p.IsActive);

            // Índice compuesto para query común: productos activos por categoría
            builder.HasIndex(p => new { p.CategoryId, p.IsActive });

            // Índice compuesto para query común: stock bajo (CurrentStock <= MinimumStock)
            builder.HasIndex(p => new { p.CurrentStock, p.MinimumStock, p.IsActive });

            // Índice para productos próximos a vencer
            builder.HasIndex(p => new { p.IsPerishable, p.ExpirationDate, p.IsActive });

            #endregion

            #region Relationships

            // Relación con Category (muchos-a-uno)
            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);  // No eliminar Category si tiene Products

            // Relación con Supplier (muchos-a-uno)
            builder
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);  // No eliminar Supplier si tiene Products

            #endregion
        }
    }
}
