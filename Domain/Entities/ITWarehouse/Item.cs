using BackOfficeApp_Domain.Common;

namespace Domain.Entities.ITWarehouse;

public class Item : AuditableEntity
{
    public Part Part { get; set; }
    public Invoice Invoice { get; set; }
    public State State { get; set; }
    public string AssetTagNumber { get; set; }
    public string SerialNumber { get; set; }
    public DateTime LastSeen { get; set; }
    public Employee Employee { get; set; }
    public Warehouse Warehouse { get; set; }
    public decimal Price { get; set; }
    public Currency Currency { get; set; }
    public DateTime? PurchaseDate { get; set; }
}
