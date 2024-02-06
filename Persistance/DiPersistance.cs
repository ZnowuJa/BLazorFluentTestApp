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
