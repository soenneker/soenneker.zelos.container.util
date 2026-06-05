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
    /// Gets the value.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="containerName">The container name.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<IZelosContainer> Get(string filePath, string containerName, CancellationToken cancellationToken = default);

}