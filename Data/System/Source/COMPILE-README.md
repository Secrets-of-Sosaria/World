# Compiling the server engine

This guide covers building the server **engine** (`World.exe` + `World.dll`). The engine
lives in `Data\System\Source` — an SDK-style project (`Source.csproj`) targeting
**.NET 10** (`net10.0-windows`).

> The game **scripts** under `Data\Scripts` are *not* built here. The running server
> recompiles them into `Data.bin` at startup via the Roslyn script compiler, so editing a
> script only needs a server restart — no engine rebuild.

## Prerequisites

* **Windows.** The engine targets `net10.0-windows` (it uses Windows Forms / `System.Drawing`),
  so it builds and runs on Windows only.
* The **[.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)** plus the
  **.NET 10 Desktop Runtime** (the `WindowsDesktop` shared framework).

## The easy way: `build.ps1`

A PowerShell script next to the project — `Data\System\Source\build.ps1` — builds and
(optionally) deploys the engine for you.

* Launch **PowerShell** and `cd` into `Data\System\Source`.

**Compile-verify only** — safe to run while the server is up; it builds to a staging
folder under `bin\` and never touches the live deployment:

```
.\build.ps1
```

**Build and deploy** — publishes framework-dependent (`win-x64`) and copies the runnable
root files (`World.exe`, `World.dll`, `*.deps.json`, `*.runtimeconfig.json`, and the
Roslyn / Drawing support DLLs) into the repo root next to `Saves` / `Data` / `Info`:

```
.\build.ps1 -Deploy
```

> **Stop the server before deploying.** `-Deploy` refuses to run while a `World` process is
> live (pass `-Force` to override). The existing root `World.exe` / `World.dll` are backed
> up to `*.bak` first.

Additional switches: `-Clean` (delete `bin` / `obj` for a full rebuild) and
`-Configuration` (defaults to `Release`).

After deploying, start the server (e.g. `startserver.bat`). On the first start the Roslyn
compiler rebuilds the script corpus into `Data.bin` (its hash changed), then the server
prints the .NET runtime version and the shard banner and loads the world.

## Manual build (for reference)

`build.ps1 -Deploy` is a thin wrapper around a framework-dependent publish:

```
dotnet publish Source.csproj -c Release -r win-x64 --self-contained false -o <output-folder>
```

Then copy the publish **root files** — not the `cs\`, `de\`, … localization subfolders or
`runtimes\` — next to `Saves` / `Data` / `Info`.

> **Why a framework-dependent folder and not a single file:** the runtime Roslyn compiler
> references framework assemblies as real files on disk, and `Core.BaseDirectory` is derived
> from `Assembly.Location` — both break under single-file publishing.
