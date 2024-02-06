using Application;
using Infrastructure;
using Persistance;

using BOAppFluentUI.Components;
using Microsoft.FluentUI.AspNetCore.Components;


namespace BOAppFluentUI;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;

        // Add services to the container.

        builder.Services.AddPersistance(configuration);
        builder.Services.AddInfrastructure(configuration);
        builder.Services.AddApplication(configuration);

        builder.Services.AddRazorComponents(options => options.DetailedErrors = true)
            .AddInteractiveServerComponents();

        builder.Services.AddFluentUIComponents();
        builder.Services.AddDataGridEntityFrameworkAdapter();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
