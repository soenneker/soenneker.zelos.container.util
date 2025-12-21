using Soenneker.Zelos.Container.Util.Abstract;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Soenneker.Extensions.String;
using Soenneker.Extensions.ValueTask;
using Soenneker.Utils.SingletonDictionary;
using Soenneker.Zelos.Abstract;
using Soenneker.Zelos.Database.Util.Abstract;

namespace Soenneker.Zelos.Container.Util;

///<inheritdoc cref="IZelosContainerUtil"/>
public sealed class ZelosContainerUtil : IZelosContainerUtil
{
    private readonly ILogger<ZelosContainerUtil> _logger;

    private readonly SingletonDictionary<IZelosContainer, string, string> _containers;

    public ZelosContainerUtil(IZelosDatabaseUtil zelosDatabaseUtil, ILogger<ZelosContainerUtil> logger)
    {
        _logger = logger;

        _containers = new SingletonDictionary<IZelosContainer, string, string>(async (key, token, filePath, containerName) =>
        {
            IZelosDatabase database = await zelosDatabaseUtil.Get(filePath!, token).NoSync();
            IZelosContainer container = await database.GetContainer(containerName!, token).NoSync();

            return container;
        });
    }

    public async ValueTask<IZelosContainer> Get(string filePath, string containerName, CancellationToken cancellationToken = default)
    {
        containerName = containerName.ToLowerInvariantFast();

        return await _containers.Get($"{filePath}:{containerName}", filePath, containerName, cancellationToken);
    }

    /// <summary>
    /// Disposes of the resources used by the ZelosContainerUtil.
    /// </summary>
    public void Dispose()
    {
        _logger.LogDebug("Disposing of ZelosContainerUtil...");

        _containers.Dispose();
    }

    /// <summary>
    /// Asynchronously disposes of the resources used by the ZelosContainerUtil.
    /// </summary>
    /// <returns>A ValueTask representing the asynchronous dispose operation.</returns>
    public ValueTask DisposeAsync()
    {
        _logger.LogDebug("Disposing of ZelosContainerUtil...");

        return _containers.DisposeAsync();
    }
}