using Microsoft.AspNetCore.Identity;

namespace Application.Entities;

public class AppUser : IdentityUser
{
   
    public string FirstName { get; set; }
    public string LastName { get; set; }
    //public string MPK { get; set; }
    //public ApplicationUser Manager { get; set; }
    //public string ManagerId { get; set; }

    // Add more properties as required by your application
}
