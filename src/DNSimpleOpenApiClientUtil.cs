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
public sealed class DNSimpleOpenApiClientUtil : IDNSimpleOpenApiClientUtil
{
    private readonly AsyncSingleton<DNSimpleOpenApiClient> _client;

    public DNSimpleOpenApiClientUtil(IDNSimpleClientUtil httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<DNSimpleOpenApiClient>(async (token, _) =>
        {
            var test = configuration.GetValueStrict<bool>("DNSimple:Test");
            var apiKey = configuration.GetValueStrict<string>("DNSimple:Token");

            HttpClient httpClient = await httpClientUtil.Get(test, token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new BearerAuthenticationProvider(apiKey), httpClient: httpClient);

            return new DNSimpleOpenApiClient(requestAdapter);
        });
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