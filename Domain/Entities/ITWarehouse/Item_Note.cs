using BackOfficeApp_Domain.Common;

namespace Domain.Entities.ITWarehouse;

public class Item_Note : AuditableEntity
{
    public Item item { get; set; }
    public Note note { get; set; }

}
