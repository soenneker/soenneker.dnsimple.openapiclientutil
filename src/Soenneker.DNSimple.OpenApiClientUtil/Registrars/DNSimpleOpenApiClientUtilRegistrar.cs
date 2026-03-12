using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.DNSimple.Client.Registrars;
using Soenneker.DNSimple.OpenApiClientUtil.Abstract;

namespace Soenneker.DNSimple.OpenApiClientUtil.Registrars;

/// <summary>
/// A .NET thread-safe singleton OpenApiClient for DNSimple
/// </summary>
public static class DNSimpleOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="DNSimpleOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddDNSimpleOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddDNSimpleClientUtilAsSingleton().TryAddSingleton<IDNSimpleOpenApiClientUtil, DNSimpleOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="DNSimpleOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddDNSimpleOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddDNSimpleClientUtilAsSingleton().TryAddScoped<IDNSimpleOpenApiClientUtil, DNSimpleOpenApiClientUtil>();

        return services;
    }
}