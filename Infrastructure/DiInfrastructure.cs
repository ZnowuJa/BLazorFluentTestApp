using Application.Interfaces;
using Application.Interfaces.Identity.Services;
using Application.Interfaces.Identity.Services;
using Infrastructure.Identity.Services;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;
public static class DiInfrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDateTime, DateTimeService>();
        //services.AddScoped<UserRegistrationService>();
        //services.AddScoped<TokenValidatedHandlerService>();
        //services.AddScoped<PostAuthenticationService>();
        //services.AddScoped<UserService>();

        //services.AddScoped<UserRegistrationService>();
        //services.AddTransient<TokenValidatedHandlerService>();
        //services.AddScoped<PostAuthenticationService>();
        //services.AddScoped<UserService>();




        return services;
    }
}
