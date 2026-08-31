using Soenneker.DNSimple.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.DNSimple.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached <see cref="DNSimpleOpenApiClient"/> backed by the configured DNSimple transport.
/// </summary>
public interface IDNSimpleOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the generated client cached by this utility instance.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The configured DNSimple client.</returns>
    ValueTask<DNSimpleOpenApiClient> Get(CancellationToken cancellationToken = default);
}
