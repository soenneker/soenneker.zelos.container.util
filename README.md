[![](https://img.shields.io/nuget/v/soenneker.zelos.container.util.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.zelos.container.util/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.zelos.container.util/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.zelos.container.util/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.zelos.container.util.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.zelos.container.util/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.zelos.container.util/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.zelos.container.util/actions/workflows/codeql.yml)

# Soenneker.Zelos.Container.Util

A DI utility that simplifies Zelos database and container access.

## Install

```bash
dotnet add package Soenneker.Zelos.Container.Util
```

## Quick start

```csharp
using Soenneker.Zelos.Container.Util.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddZelosContainerUtilAsSingleton();
```

Adds `IZelosContainerUtil` as a singleton service.

## What you get

- `IZelosContainerUtil` — A DI utility that simplifies Zelos database and container access.
- `ZelosContainerUtilRegistrar` — A DI utility that simplifies Zelos database and container access.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `ZelosContainerUtilRegistrar.AddZelosContainerUtilAsSingleton(services)` | Adds `IZelosContainerUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `ZelosContainerUtilRegistrar.AddZelosContainerUtilAsScoped(services)` | Adds `IZelosContainerUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Dispose instances you own when their scope ends so held resources can be released.
