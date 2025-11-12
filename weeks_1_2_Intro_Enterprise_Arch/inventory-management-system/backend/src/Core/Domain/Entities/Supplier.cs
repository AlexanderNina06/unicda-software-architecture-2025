using System;
using Inventory.Domain.Common;

namespace Inventory.Domain.Entities;

public class Supplier : AuditableBaseEntity
{
    public string CommercialName { get; set; }
    public string RNC { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string ContactName { get; set; }
    public string ContactPhone { get; set; }
    public string ContactEmail { get; set; }
    public string Notes { get; set; }
    public bool IsActive { get; set; }
    public ICollection<Product> Products { get; set; }
}