# Secrets of DotNet10

## NOTICE: Technical Fork

This fork is a technical fork of https://github.com/Secrets-of-Sosaria/World
Release: Humility, Dec 20, 2025, which was latest as of 6/27/2026.

The purpose of this fork is to establish a clean foundation on the .NET 10 framework. For your convenience, a migration HowTo-document has been added.

Other than noted below, only modifications strictly related to .NET 10 conversion were made.

### Target Audience

Implementers. Please excuse not making a proper pull request; I'm not super familiar with github, and I want this port to stand on its own.
As this is a technical fork, I have not altered any project files, most prominently the original server name "Secrets of Sosaria", as I wanted to change only the minimum of files. If
you download/fork this repo, please honor the condition mentioned in the manual to give your project a different name than the parent project. If you are a SoS maintainer: I'm trying to save you some work. Should you be unhappy regardless, let me know how specifically to make you less unhappy. Your civility and consideration will be appreciated and reciprocated.

### Testing

Server has been tested under Windows 11. If you run this under any other environments, or want to share your experience running this project on your machine, please leave a comment.

### Other Additions

- World Load: mobiles causing exceptions are logged and discarded, instead of terminating the app. We rely on the world spawn to re-populate mobiles, but if no load errors occur, the modification should be transparent.
- Server maintains and displays independent build number on startup
- Server truthfully reports .NET environment during startup (Main.cs), Crash Logging (CrashGuard.cs), Sending Server Info Wire Packet (Remote.cs) and inside the [Admin dialog (AdminGump.cs).

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

