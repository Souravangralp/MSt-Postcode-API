using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MSt_Postcode_API.Application.Common.Interfaces;
using MSt_Postcode_API.Infrastructure.Data;
using MSt_Postcode_API.Infrastructure.Data.Interceptors;

namespace MSt_Postcode_API.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        RegisterServices(services);

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);

        services.AddAuthorizationBuilder();

        services.AddSingleton(TimeProvider.System);

        return services;
    }

    /// <summary>
    /// This method is being used to register services to builder.
    /// </summary>
    /// <param name="services"></param>
    private static void RegisterServices(this IServiceCollection services)
    {
        var servicesAssembly = Assembly.Load("MSt_Postcode_API.Infrastructure");

        var interfacesAssembly = Assembly.Load("MSt_Postcode_API.Application");

        var serviceTypes = servicesAssembly.GetTypes();

        var interfaceTypes = interfacesAssembly.GetTypes();

        var registeredInterfaces = interfaceTypes.Where(t => t.IsInterface && t.Name.EndsWith("Service"));

        var registeredServices = serviceTypes.Where(t => t.IsClass && t.Name.EndsWith("Service"));

        foreach (var interfaceType in registeredInterfaces)
        {
            var implementationType = registeredServices.FirstOrDefault(t => interfaceType.IsAssignableFrom(t));

            if (implementationType != null)
            {
                services.AddScoped(interfaceType, implementationType);
            }
        }
    }
}
