using System;
using Inventory.Domain.Common;

namespace Inventory.Domain.Entities;

public class Category : AuditableBaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }  
    public bool IsActive { get; set; } = true;  
    public ICollection<Product> Products { get; set; } = new List<Product>();

}
