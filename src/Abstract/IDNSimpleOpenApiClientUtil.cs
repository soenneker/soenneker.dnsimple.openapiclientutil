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
    ValueTask<DNSimpleOpenApiClient> Get(CancellationToken cancellationToken = default);
}
