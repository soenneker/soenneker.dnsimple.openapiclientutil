using Soenneker.DNSimple.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.DNSimple.OpenApiClientUtil.Tests;

[Collection("Collection")]
public class DNSimpleOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IDNSimpleOpenApiClientUtil _kiotaclient;

    public DNSimpleOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _kiotaclient = Resolve<IDNSimpleOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
