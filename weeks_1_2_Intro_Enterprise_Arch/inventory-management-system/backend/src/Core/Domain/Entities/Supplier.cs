using System;
using Inventory.Domain.Common;

namespace Inventory.Domain.Entities;

public class Supplier : AuditableBaseEntity
{
    public string CommercialName { get; set; } = string.Empty;
    public string RNC { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? ContactName { get; set; }
    public string? ContactPhone { get; set; }
    public string? ContactEmail { get; set; }
    public string? Notes { get; set; }
    public bool IsActive { get; set; } = true;
    public ICollection<Product> Products { get; set; } = new List<Product>();
}