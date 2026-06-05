using Soenneker.DNSimple.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.DNSimple.OpenApiClientUtil.Abstract;

/// <summary>
/// A .NET thread-safe singleton HttpClient for 
/// </summary>
public interface IDNSimpleOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<DNSimpleOpenApiClient> Get(CancellationToken cancellationToken = default);
}
