using Application.Entities;

namespace Application.Interfaces.Identity.Services;
public interface IPostAuthenticationService
{
    Task AssignDefaultRoleIfNotExistAsync(AppUser user);
    Task<List<string>> GetRolesForUserAsync(string userId);
}