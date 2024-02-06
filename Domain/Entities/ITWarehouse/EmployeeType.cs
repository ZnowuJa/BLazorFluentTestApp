using BackOfficeApp_Domain.Common;

namespace Domain.Entities.ITWarehouse;
public class EmployeeType : SmallAuditableEntity
{
    public string Name { get; set; }
}
