//using ProductMatrix.Infrastructure.Identity;
using Microsoft.Extensions.Configuration;
using ProductMatrix.Infrastructure.Data;
using ProductMatrix.Infrastructure.Data.Interceptors;
using ProductMatrix.Infrastructure.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
        services.AddScoped<IGetDefaultSetting, GetDefaultSetting>();

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

        //services
        //    .AddIdentityCore<ApplicationUser>()
        //    .AddRoles<IdentityRole>()
        //    .AddEntityFrameworkStores<ApplicationDbContext>()
        //    .AddApiEndpoints();

        services.AddSingleton(TimeProvider.System);
        //services.AddTransient<IIdentityService, IdentityService>();

        //services.AddAuthorization(options =>
        //    options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator)));

        return services;
    }

    /// <summary>
    /// This method is being used to register services to builder.
    /// </summary>
    /// <param name="services"></param>
    private static void RegisterServices(this IServiceCollection services)
    {
        var servicesAssembly = Assembly.Load("ProductMatrix.Infrastructure");

        var interfacesAssembly = Assembly.Load("ProductMatrix.Application");

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
