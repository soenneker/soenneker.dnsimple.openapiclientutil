using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.DNSimple.Client.Abstract;
using Soenneker.DNSimple.OpenApiClient;
using Soenneker.Extensions.Configuration;
using Soenneker.DNSimple.OpenApiClientUtil.Abstract;
using Soenneker.Extensions.ValueTask;
using Soenneker.Kiota.BearerAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.DNSimple.OpenApiClientUtil;

///<inheritdoc cref="IDNSimpleOpenApiClientUtil"/>
// ReSharper disable once InconsistentNaming
public sealed class DNSimpleOpenApiClientUtil : IDNSimpleOpenApiClientUtil
{
    private readonly AsyncSingleton<DNSimpleOpenApiClient> _client;
    private readonly IDNSimpleClientUtil _httpClientUtil;
    private readonly IConfiguration _configuration;

    public DNSimpleOpenApiClientUtil(IDNSimpleClientUtil httpClientUtil, IConfiguration configuration)
    {
        _httpClientUtil = httpClientUtil;
        _configuration = configuration;
        _client = new AsyncSingleton<DNSimpleOpenApiClient>(CreateClient);
    }

    private async ValueTask<DNSimpleOpenApiClient> CreateClient(CancellationToken token)
    {
        var apiKey = _configuration.GetValueStrict<string>("DNSimple:Token");

        HttpClient httpClient = await _httpClientUtil.Get(token).NoSync();

        var requestAdapter = new HttpClientRequestAdapter(new BearerAuthenticationProvider(apiKey), httpClient: httpClient);

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