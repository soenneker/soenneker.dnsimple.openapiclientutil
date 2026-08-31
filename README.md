[![](https://img.shields.io/nuget/v/soenneker.dnsimple.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.dnsimple.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.dnsimple.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.dnsimple.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.dnsimple.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.dnsimple.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.dnsimple.openapiclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.dnsimple.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.DNSimple.OpenApiClientUtil

Provides a lazily created, cached DNSimple OpenAPI client backed by `Soenneker.DNSimple.Client`.

## Installation

```bash
dotnet add package Soenneker.DNSimple.OpenApiClientUtil
```

## Configuration and registration

```json
{
  "DNSimple": {
    "Token": "your-api-token",
    "Test": false
  }
}
```

```csharp
using Soenneker.DNSimple.OpenApiClientUtil.Registrars;

services.AddDNSimpleOpenApiClientUtilAsScoped();
```

## Usage

```csharp
using Soenneker.DNSimple.OpenApiClientUtil.Abstract;

public sealed class DNSimpleIdentityReader(IDNSimpleOpenApiClientUtil clients)
{
    public async Task Read(CancellationToken cancellationToken)
    {
        var client = await clients.Get(cancellationToken);
        var identity = await client.Whoami.GetAsync(cancellationToken: cancellationToken);
    }
}
```

Use `AddDNSimpleOpenApiClientUtilAsSingleton()` when the application should share one generated client. Both registrations borrow the singleton HTTP provider, so disposing a scoped utility does not remove the shared `HttpClient`; the provider owns and disposes it at application shutdown.
