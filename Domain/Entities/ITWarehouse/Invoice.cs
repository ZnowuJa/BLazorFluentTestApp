using BackOfficeApp_Domain.Common;

namespace Domain.Entities.ITWarehouse;

public class Invoice : AuditableEntity
{
    public string? Number { get; set; }
    public Company Company { get; set; }   
    public DateTime Date {get; set;}
    public decimal? TotalNet { get; set; }
    public Currency Currency { get; set; }
    public bool ItemsGenerated {  get; set; }
}