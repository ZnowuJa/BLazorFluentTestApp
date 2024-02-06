using Application.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Interfaces.Identity.Services;
public interface IUserService
{
    Task<bool> AssignRole(string userId, string roleName);
    Task<List<string>> GetRoles();
    Task<AppUser> GetUserByPreferredUsername(string preferredUsername);
    Task<List<string>> GetUserRoles(AppUser user);
    Task<List<AppUser>> GetUsers();
    Task<IdentityResult> RegisterUserAsync(AppUser user, string password);
}