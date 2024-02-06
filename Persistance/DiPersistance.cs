using Application.Entities;
using Application.Interfaces;
using Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using System.Security.Claims;

namespace Persistance;
public static class DiPersistance
{
    public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ApplicationDbContextConnection"))
        //.EnableSensitiveDataLogging()
        );

        services.AddScoped<IAppDbContext, AppDbContext>();

        //services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
        //    .AddRoles<IdentityRole>()
        //    .AddEntityFrameworkStores<AppDbContext>();


        //services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
        //    .AddMicrosoftIdentityWebApp(configuration.GetSection("AzureAd"));
        //services.AddControllersWithViews()
        //    .AddMicrosoftIdentityUI();

        //services.Configure<OpenIdConnectOptions>(OpenIdConnectDefaults.AuthenticationScheme, options =>
        //{
        //    options.Events = new OpenIdConnectEvents
        //    {
        //        OnTokenValidated = async context =>
        //        {
        //            var tokenValidatedHandler = context.HttpContext.RequestServices.GetRequiredService<TokenValidatedHandlerService>();
        //            await tokenValidatedHandler.HandleTokenValidation(context);
                   
        //        }
        //    };
        //});

        //services.AddAuthorization(options =>
        //{
        //    options.AddPolicy("User", policy => policy.RequireRole("User", "Manager", "Technician", "Administrator", "AppAdmin"));
        //    options.AddPolicy("Manager", policy => policy.RequireRole("Manager", "Technician", "Administrator", "AppAdmin"));
        //    options.AddPolicy("Technician", policy => policy.RequireRole("Technician", "Administrator", "AppAdmin"));
        //    options.AddPolicy("Administrator", policy => policy.RequireRole("Administrator", "AppAdmin"));
        //    options.AddPolicy("AppAdmin", policy => policy.RequireRole("AppAdmin"));

        //    options.FallbackPolicy = options.DefaultPolicy;
        //});

        return services;
    }
}
//
//THIS IS A SPARE PART OF ONTOKENVALIDATED MOVED TO TKOENVALIDATEDhANDLERsERVICE
//
//var externalUserData = new Dictionary<string, string>();

//var claims = context.Principal.Claims;

//var preferredUsername = claims.FirstOrDefault(c => c.Type == "preferred_username")?.Value;
//externalUserData["preferredUsername"] = preferredUsername;

////var userEmail = context.Principal?.FindFirst(ClaimTypes.)?.Value;

//if ((preferredUsername == null) || !(preferredUsername.EndsWith("@gmail.com")))
//{   //context.HandleResponse(); // Discontinue the authentication process
//    context.Response.Redirect("/unauthorized"); // Redirect to the unauthorized page
//    //context.Response.StatusCode = StatusCodes.Status403Forbidden;
//    context.Fail("Access denied. Your email domain is not allowed.");
//    return;
//}

//var name = claims.FirstOrDefault(c => c.Type == "name")?.Value;
//externalUserData["name"] = name;

//var userService = context.HttpContext.RequestServices.GetRequiredService<UserService>();
//var user = await userService.GetUserByPreferredUsername(preferredUsername);
//if (user != null)
//{
//    // Get the roles associated with the user
//    var roles = await userService.GetUserRoles(user);

//    // Add roles as claims to the user's identity
//    foreach (var role in roles)
//    {
//        var roleClaim = new Claim(ClaimTypes.Role, role);
//        context.Principal.Identities.FirstOrDefault()?.AddClaim(roleClaim);
//        Console.WriteLine(role);
//    }
//}

//var userRegistrationService = context.HttpContext.RequestServices.GetRequiredService<UserRegistrationService>();
//await userRegistrationService.CheckRoles();
//await userRegistrationService.RegisterUserFromExternalProviderAsync(preferredUsername, preferredUsername, name);