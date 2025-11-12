using System;
using Inventory.Domain.Common;
using Inventory.Domain.enums;

namespace Inventory.Domain.Entities;

public class InventoryMovement : AuditableBaseEntity
{
    public int ProductId { get; set; }
    public MovementType Type { get; set; }
    public int Quantity { get; set; }
    public int StockAfterMovement { get; set; }
    public string Reason { get; set; } = string.Empty;  // explica el movimiento
    // Optional, based on movement type
    public string? InvoiceNumber { get; set; } // solo para compras
    public string? Destination { get; set; }  // solo para salidas
    public string? Notes { get; set; } 
    public DateTime MovementDate { get; set; }
    public string UserId { get; set; } = string.Empty; 
    public Product Product { get; set; } = null!;
}
