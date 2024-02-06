using Application.Entities;
using Application.Interfaces.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;


namespace Infrastructure.Identity.Services;
public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;


    public UserService(
        UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    public async Task<AppUser> GetUserByPreferredUsername(string preferredUsername)
    {
        var user = await _userManager.FindByNameAsync(preferredUsername);
        //_logger.Information("From userservice : user : " +  user + preferredUsername);
        return user;
    }
    public async Task<IdentityResult> RegisterUserAsync(AppUser user, string password)
    {
        var result = await _userManager.CreateAsync(user);
        if (result.Succeeded)
        {
            // Assign default role to the registered user
            await _userManager.AddToRoleAsync(user, "User");
        }
        return result;
    }
    public async Task<List<string>> GetUserRoles(AppUser user)
    {
        var rl = await _userManager.GetRolesAsync(user);
        return (List<string>)rl;
    }
    public async Task<List<AppUser>> GetUsers()
    {
        return await _userManager.Users.ToListAsync();
    }
    public async Task<List<String>> GetRoles()
    {
        return await _roleManager.Roles.Select(x => x.Name).ToListAsync();
    }

    //public async Task<List<String>> GetUserRoles(AppUser user)
    //{
    //    List<string> roles = new List<String>();

    //    roles = await _userManager.GetRolesAsync(user);
    //    return OK(roles);
    //}

    public async Task<bool> AssignRole(string userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return false;
        }

        var result = await _userManager.AddToRoleAsync(user, roleName);

        return result.Succeeded;
    }

}
