using System.Threading.Tasks;
using AwesomeAssertions;
using Soenneker.Tests.HostedUnit;
using Soenneker.Zelos.Abstract;
using Soenneker.Zelos.Container.Util.Abstract;

namespace Soenneker.Zelos.Container.Util.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class ZelosContainerUtilTests : HostedUnitTest
{
    private readonly IZelosContainerUtil _util;

    public ZelosContainerUtilTests(Host host) : base(host)
    {
        _util = Resolve<IZelosContainerUtil>(true);
    }

    [Test]
    public async ValueTask GetContainer_should_get_container()
    {
        IZelosContainer container = await _util.Get("test.json", "test", CancellationToken);
        container.Should().NotBeNull();
    }
}