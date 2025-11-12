using System;
using Inventory.Domain.enums;

namespace Inventory.Domain.Entities;

public class InventoryMovement
{
  public int Id { get; set; }
    public int ProductId { get; set; }
    public MovementType Type { get; set; } 
    public int Quantity { get; set; }
    public int StockAfterMovement { get; set; }
    public string Reason { get; set; }
    public string InvoiceNumber { get; set; }
    public string Destination { get; set; }
    public string Notes { get; set; }
    public DateTime MovementDate { get; set; }
    public string UserId { get; set; }
    public Product Product { get; set; }

}
