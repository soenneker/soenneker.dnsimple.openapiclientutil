using Soenneker.DNSimple.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.DNSimple.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class DNSimpleOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IDNSimpleOpenApiClientUtil _kiotaclient;

    public DNSimpleOpenApiClientUtilTests(Host host) : base(host)
    {
        _kiotaclient = Resolve<IDNSimpleOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
