using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Zelos.Container.Util.Abstract;
using Soenneker.Zelos.Database.Util.Registrars;

namespace Soenneker.Zelos.Container.Util.Registrars;

/// <summary>
/// A DI utility that simplifies Zelos database and container access
/// </summary>
public static class ZelosContainerUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IZelosContainerUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddZelosContainerUtilAsSingleton(this IServiceCollection services)
    {
        services.AddZelosDatabaseUtilAsSingleton().TryAddSingleton<IZelosContainerUtil, ZelosContainerUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IZelosContainerUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddZelosContainerUtilAsScoped(this IServiceCollection services)
    {
        services.AddZelosDatabaseUtilAsSingleton().TryAddScoped<IZelosContainerUtil, ZelosContainerUtil>();

        return services;
    }
}