using BackOfficeApp_Domain.Common;

namespace Domain.Entities.ITWarehouse;

public class Employee : AuditableEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? IdentityUserId { get; set; }
    public string? IdentityUserName { get; set; }
    public string? ThirdPartyId { get; set; }
    public string? MobileNumber { get; set; }
    public string? PhoneNumber { get; set; }
    public Employee? Manager { get; set; }
    public EmployeeType? Type{ get; set; }
    public string? DG {  get; set; } = string.Empty;
    public string? CC { get; set; } = string.Empty;

}
