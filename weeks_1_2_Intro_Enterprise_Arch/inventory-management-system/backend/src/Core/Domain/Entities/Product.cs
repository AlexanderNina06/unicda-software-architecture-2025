using System;
using Inventory.Domain.Common;
using Inventory.Domain.enums;

namespace Inventory.Domain.Entities;

public class Product : AuditableBaseEntity
{
    public string Sku { get; set; } = string.Empty; 
    public string Name { get; set; } = string.Empty; 
    public string? Description { get; set; }  
    public int CategoryId { get; set; }
    public int SupplierId { get; set; }
    public int CurrentStock { get; set; }
    public int MinimumStock { get; set; }
    public int? MaximumStock { get; set; } 
    public decimal CostPrice { get; set; }
    public decimal SalePrice { get; set; }
    public CurrencyCode Currency { get; set; }
    public string? ImageUrl { get; set; }  
    public string? Barcode { get; set; } 
    public string? StorageLocation { get; set; } 
    public bool IsPerishable { get; set; }  
    public DateTime? ExpirationDate { get; set; } 
    public bool IsActive { get; set; } = true;  

    // Navigation properties
    public Category Category { get; set; } = null!;  
    public Supplier Supplier { get; set; } = null!; 
    public ICollection<InventoryMovement> InventoryMovements { get; set; } = new List<InventoryMovement>();
    public ICollection<Alert> Alerts { get; set; } = new List<Alert>();
}


