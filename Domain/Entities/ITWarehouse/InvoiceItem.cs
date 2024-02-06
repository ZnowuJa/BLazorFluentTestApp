using BackOfficeApp_Domain.Common;

namespace Domain.Entities.ITWarehouse;
public class InvoiceItem : AuditableEntity
{
    public string? Name { get; set; }
    public Part? Part { get; set; }
    public decimal Qty { get; set; }
    public Unit Unit { get; set; }
    public decimal UnitNetPrice { get; set; }
    public Invoice Invoice { get; set; }
}

