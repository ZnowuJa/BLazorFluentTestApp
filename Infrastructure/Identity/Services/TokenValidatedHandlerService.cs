using Application.Interfaces.Identity.Services;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System.Security.Claims;

namespace Infrastructure.Identity.Services;
public class TokenValidatedHandlerService : ITokenValidatedHandlerService
{
    private readonly IUserService _userService;
    private readonly IUserRegistrationService _userRegistrationService;

    public TokenValidatedHandlerService(UserService userService, UserRegistrationService userRegistrationService)
    {
        _userService = userService;
        _userRegistrationService = userRegistrationService;
    }

    public async Task HandleTokenValidation(TokenValidatedContext context)
    {
        var claims = context.Principal.Claims;
        var preferredUsername = claims.FirstOrDefault(c => c.Type == "preferred_username")?.Value;

        if (preferredUsername == null || !preferredUsername.EndsWith("@porscheinterauto.pl"))
        {
            context.Response.Redirect("/unauthorized");
            context.Fail("Access denied. Your email domain is not allowed.");
            return;
        }

        var name = claims.FirstOrDefault(c => c.Type == "name")?.Value;

        var user = await _userService.GetUserByPreferredUsername(preferredUsername);
        if (user != null)
        {
            var roles = await _userService.GetUserRoles(user);
            foreach (var role in roles)
            {
                var roleClaim = new Claim(ClaimTypes.Role, role);
                context.Principal.Identities.FirstOrDefault()?.AddClaim(roleClaim);
                Console.WriteLine(role);
            }

            return;
        }

        await _userRegistrationService.CheckRoles();
        await _userRegistrationService.RegisterUserFromExternalProviderAsync(preferredUsername, preferredUsername, name);
    }
}
