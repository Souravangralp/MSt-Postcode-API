using System.Reflection;
using ProductMatrix.Application.Common.Behaviours;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        });

        RegisterServices(services);

        return services;
    }

    /// <summary>
    /// This method is being used to register the services which are defined inside of application assembly to the builder. so we done have to register it manually.
    /// This method is being currently used to register facade services as of now.
    /// </summary>
    private static void RegisterServices(this IServiceCollection services)
    {
        var servicesAssembly = Assembly.Load("ProductMatrix.Application").GetTypes();

        var serviceTypes = servicesAssembly.Where(t => t.IsClass && t.Name.EndsWith("Service"));

        var interfaceTypes = servicesAssembly.Where(t => t.IsInterface && t.Name.EndsWith("Service"));

        foreach (var interfaceType in interfaceTypes)
        {
            var implementationType = serviceTypes.FirstOrDefault(t => interfaceType.IsAssignableFrom(t));

            if (implementationType != null)
            {
                services.AddScoped(interfaceType, implementationType);
            }
        }
    }
}
