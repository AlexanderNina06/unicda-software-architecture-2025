using System;
using Inventory.Domain.enums;

namespace Inventory.Domain.Entities;

public class Alert
{
    public int ProductId { get; set; }
    public AlertType Type { get; set; } 
    public string Message { get; set; }
    public bool IsViewed { get; set; }
    public bool IsResolved { get; set; }
    public DateTime? ResolvedDate { get; set; }
    public Product Product { get; set; }
}
