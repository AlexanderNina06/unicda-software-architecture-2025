using Inventory.Domain.Common;
using Inventory.Domain.enums;
using System;

namespace Inventory.Domain.Entities;

public class Alert : AuditableBaseEntity
{
    public int ProductId { get; set; }
    public AlertType Type { get; set; }
    public string Message { get; set; } = string.Empty;
    public bool IsViewed { get; set; } = false; 
    public bool IsResolved { get; set; } = false; 
    public DateTime? ResolvedDate { get; set; }
    public string? ResolvedBy { get; set; }  
    public Product Product { get; set; } = null!;
}
