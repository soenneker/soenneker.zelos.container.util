using System;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Zelos.Abstract;

namespace Soenneker.Zelos.Container.Util.Abstract;

/// <summary>
/// A DI utility that simplifies Zelos database and container access
/// </summary>
public interface IZelosContainerUtil : IAsyncDisposable, IDisposable
{
    /// <summary>
    /// Returns the configured zelos Container used by the Zelos Container.
    /// </summary>
    /// <param name="filePath">Path of the file to use.</param>
    /// <param name="containerName">Name of the container to target.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested zelos Container.</returns>
    ValueTask<IZelosContainer> Get(string filePath, string containerName, CancellationToken cancellationToken = default);

}
