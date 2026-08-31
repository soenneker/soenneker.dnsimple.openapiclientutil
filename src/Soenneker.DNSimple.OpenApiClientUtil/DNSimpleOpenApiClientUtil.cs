using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.DNSimple.Client.Abstract;
using Soenneker.DNSimple.OpenApiClient;
using Soenneker.DNSimple.OpenApiClientUtil.Abstract;
using Soenneker.Extensions.ValueTask;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.DNSimple.OpenApiClientUtil;

public sealed class DNSimpleOpenApiClientUtil : IDNSimpleOpenApiClientUtil
{
    private readonly AsyncSingleton<DNSimpleOpenApiClient> _client;
    private readonly IDNSimpleClientUtil _httpClientUtil;

    public DNSimpleOpenApiClientUtil(IDNSimpleClientUtil httpClientUtil, IConfiguration configuration)
    {
        _httpClientUtil = httpClientUtil;
        _client = new AsyncSingleton<DNSimpleOpenApiClient>(CreateClient);
    }

    private async ValueTask<DNSimpleOpenApiClient> CreateClient(CancellationToken token)
    {
        HttpClient httpClient = await _httpClientUtil.Get(token).NoSync();

        var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

        return new DNSimpleOpenApiClient(requestAdapter);
    }

    public ValueTask<DNSimpleOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
