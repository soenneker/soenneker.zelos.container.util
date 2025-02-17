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
    ValueTask<IZelosContainer> Get(string filePath, string containerName, CancellationToken cancellationToken = default);

}