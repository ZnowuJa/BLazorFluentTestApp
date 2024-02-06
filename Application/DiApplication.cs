using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Behaviors;
using FluentValidation;
using System.Reflection;
using FluentValidation.AspNetCore;
using Application.Validation;

namespace Application;
public static class DiApplication
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddScoped(IUserService, UserService)
        var assembly = typeof(DiApplication).Assembly;
        services.AddValidatorsFromAssembly(assembly);
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(assembly));
        services.AddAutoMapper(assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>)); //ta validacja dziala ale chyba za duzo jebania sie bedzie w obsluzeniu tego na formularzu

        return services;
    }
}
