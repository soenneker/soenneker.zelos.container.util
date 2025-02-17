using System.Threading.Tasks;
using FluentAssertions;
using Soenneker.Tests.FixturedUnit;
using Soenneker.Zelos.Abstract;
using Soenneker.Zelos.Container.Util.Abstract;
using Xunit;

namespace Soenneker.Zelos.Container.Util.Tests;

[Collection("Collection")]
public class ZelosContainerUtilTests : FixturedUnitTest
{
    private readonly IZelosContainerUtil _util;

    public ZelosContainerUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IZelosContainerUtil>(true);
    }

    [Fact]
    public async ValueTask GetContainer_should_get_container()
    {
        IZelosContainer container = await _util.Get("test.json", "test", CancellationToken);
        container.Should().NotBeNull();
    }
}