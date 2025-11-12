using System;
using Inventory.Domain.Common;

namespace Inventory.Domain.Entities;

public class Category : AuditableBaseEntity
{
  public string Name { get; set; } = string.Empty;

  public string Description { get; set; } = string.Empty;

  public bool isActive { get; set; } = true; 

  public ICollection<Product>? products { get; set; }

}
