# Secrets of DotNet10

## Keywords
uo server, uoserver, dotnet10, .net10, R&R-server, uodyssey, sosaria

## NOTICE: Technical Fork

This fork is a technical fork of https://github.com/Secrets-of-Sosaria/World
Release: Humility, Dec 20, 2025, which was latest as of 6/27/2026.

This is NOT a stand-alone server (for that, you'd have to re-brand it).

The purpose of this fork is to establish a clean foundation on the .NET 10 framework. 
Status: runs on **.NET 10.0.x**; all 5,076 runtime scripts compile; existing 4.x world saves load unchanged. HW-tested on Windows 11.

### Target Audience

Implementers. 
As this is a technical fork, I have not altered any project files, most prominently the original server name "Secrets of Sosaria", as I wanted to change only the minimum of files. If
you download/fork this repo, please honor the condition mentioned in the manual to give your project a different name than the parent project. If you are a SoS maintainer: I'm trying to save you some work. Should you be unhappy regardless, let me know how specifically to make you less unhappy. Your civility and consideration will be appreciated and reciprocated.

### Requirements
- Windows (x64) with the **.NET 10 SDK** and the **Windows Desktop** runtime installed.
- A UO client to connect (e.g. TazUO). Client files are **not** part of this repo.

## Build & run
The engine (`World.exe`) is built from `Data/System/Source`; the game scripts under `Data/Scripts` are compiled **at runtime** by the server (no separate build step).


### Building

```powershell
# from Data\System\Source — compile-verify only (safe while the server runs):
./build.ps1
# stop the server first, then build + deploy the engine to the repo root:
./build.ps1 -Deploy
```
Then start the server from the repo root:

`startserver.bat`        (= World.exe -debug)
On first start the server recompiles the scripts into Data/Data.bin via Roslyn, prints the runtime (.NET 10.0.x) and shard build, loads the world, and reports "You may now play".

build.ps1 -Deploy publishes framework-dependent and copies the engine files into the repo root (it is not single-file — the runtime script compiler needs real assembly files on
disk and a non-empty Assembly.Location). The previous engine is backed up to *.bak.

The Server has been tested under Windows 11. If you run this under any other environments, or want to share your experience running this project on your machine, please leave a comment.

### How the Conversion Works

The runtime script compiler (ScriptCompiler.cs) was ported from System.CodeDom/CSharpCodeProvider (which throws on modern .NET) to Roslyn (Microsoft.CodeAnalysis.CSharp); references come from TRUSTED_PLATFORM_ASSEMBLIES (no GAC).
Engine project: retargeted to net10.0-windows; one package (Microsoft.CodeAnalysis.CSharp).
Save format: runtime-portable (explicit UTF-8, DateTime.Ticks, no BinaryFormatter), so **4.x worlds load as-is.**
Only 3 files needed changes (System.Web ×2, Reflection.Emit save-to-disk). 

### Other Additions

- World Load: mobiles causing exceptions are logged and discarded, instead of terminating the app. We rely on the world spawn to re-populate mobiles, but if no load errors occur, the modification should be transparent.
- Server maintains and displays independent build number on startup
- Server truthfully reports .NET environment during startup (Main.cs), Crash Logging (CrashGuard.cs), Sending Server Info Wire Packet (Remote.cs) and inside the [Admin dialog (AdminGump.cs).

### So which files actually changed?

Fine, here you go.

Modified source (9): World.cs, Main.cs, ScriptCompiler.cs, Source.csproj (engine) · AdminGump.cs, CrashGuard.cs, Reporting.cs, Errors.cs, Emitter.cs (scripts)
New source (3): ShardVersion.cs, HtmlTextWriterCompat.cs, build.ps1
Runnable binaries — new (5): World.dll, World.deps.json, World.runtimeconfig.json, Microsoft.CodeAnalysis.dll, Microsoft.CodeAnalysis.CSharp.dll
Runnable binary — updated (1): World.exe (829,440 → 278,528 bytes; months-old net4.0 → net10 apphost)

### On Warnings

"But I receive 30ish warnings right now, what gives?"

These are not introduced by the migration. They're long-standing warnings in the original RunUO/SoS script corpus — the old CodeDom/`csc` compiler emitted them too. 
What changed is that the ported `Display()` now *counts and surfaces* them (`done (35 warnings)`), whereas the old code only printed warnings when there was *also* an error. 
So the migration made them visible; it didn't create them. And all 5,076 scripts compile — these are advisory, zero of them errors.

**Three tiers:**

1. **Pure code hygiene (~26 — CS0169, CS0219, CS0414, CS0105, CS0472).** Dead fields/locals, duplicate `using`s, a couple of always-true null checks. No runtime impact at all. Safe to ignore; cleanable opportunistically if you ever want a quieter build.

2. **Obsolete-API deprecations that still work (8 — CS0618, SYSLIB0021).** `System.TimeZone` and the derived crypto types (`SHA1Managed` etc.) are *deprecated* on modern .NET but still present and functional. They compile and run fine on net10 — they're just future-removal candidates. Low priority modernization (one-line swaps each), not a correctness issue today.

3. **The one with real teeth — SYSLIB0006: `Thread.Abort()` (×2, in `IrcConnection.cs`).** This is the only warning that flags a genuine **runtime behavior change**: on modern .NET `Thread.Abort()` doesn't just warn, it **throws `PlatformNotSupportedException` when called**. So if the IRC chat-bridge feature is ever exercised (the path that aborts its worker thread), it will throw. It compiles clean and is dormant unless that feature runs. The proper fix would be a cooperative shutdown (a cancellation flag / `Thread` left to exit, or `CancellationToken`) instead of `Abort()`.

**Conclusion:**

you're good to go. Enjoy the .NET10 version!

