<#
.SYNOPSIS
    Build (and optionally deploy) the Secrets of Sosaria server engine on .NET 10.

.DESCRIPTION
    The ENGINE lives in Data\System\Source (SDK-style Source.csproj, net10.0-windows). The game SCRIPTS
    under Data\Scripts are NOT built here -- the running server recompiles them into Data.bin at startup
    via the Roslyn ScriptCompiler.

    Two modes:

      (default)   SAFE compile-verify. Builds to a staging folder under Source\bin and never touches the
                  live deployment, so it is safe to run while the server is up.

      -Deploy     Publishes framework-dependent (dotnet publish -r win-x64 --self-contained false) and
                  copies the publish ROOT FILES (World.exe + World.dll + *.deps.json + *.runtimeconfig.json
                  + the Roslyn/Drawing/etc. DLLs) into the repo root next to Saves/Data/Info. The server
                  MUST be stopped first; the script refuses if a 'World' process is running (-Force to
                  override). Existing root World.exe/World.dll are backed up to *.bak first.

    WHY a framework-dependent FOLDER and not single-file: the runtime Roslyn ScriptCompiler references
    framework assemblies as REAL files (MetadataReference.CreateFromFile), and Core.BaseDirectory is
    derived from Assembly.Location -- both break under single-file. See SoS_dotnet10_howto.md §6.

    Requires the .NET 10 SDK + the WindowsDesktop runtime (UseWindowsForms / System.Drawing).

.PARAMETER Deploy   Publish and replace the live root deployment (backs up first).
.PARAMETER Force    Proceed with -Deploy even if a 'World' server process is running. Use with care.
.PARAMETER Clean    Remove bin/obj and staging before building (full rebuild).
.PARAMETER Configuration   Build configuration. Default: Release.

.EXAMPLE  .\build.ps1            # compile-verify only (safe while the server runs)
.EXAMPLE  .\build.ps1 -Deploy    # stop the server first, then publish + deploy to the repo root
#>
[CmdletBinding()]
param(
    [switch]$Deploy,
    [switch]$Force,
    [switch]$Clean,
    [string]$Configuration = 'Release'
)

$ErrorActionPreference = 'Stop'

function Write-Step($msg) { Write-Host ""; Write-Host "==> $msg" -ForegroundColor Cyan }
function Write-Ok($msg)   { Write-Host "    $msg" -ForegroundColor Green }
function Write-Note($msg) { Write-Host "    $msg" -ForegroundColor Yellow }

# --- Resolve paths (this script lives at <root>\Data\System\Source) ---
$ScriptDir  = $PSScriptRoot
$Csproj     = Join-Path $ScriptDir 'Source.csproj'
$RepoRoot   = (Resolve-Path (Join-Path $ScriptDir '..\..\..')).Path
$LiveExe    = Join-Path $RepoRoot 'World.exe'
$LiveDll    = Join-Path $RepoRoot 'World.dll'
$StageDir   = Join-Path $ScriptDir ('bin\stage-' + $Configuration)
$PublishDir = Join-Path $ScriptDir ('bin\publish-' + $Configuration)

if (-not (Test-Path $Csproj)) { throw "Source.csproj not found at $Csproj" }
if (-not (Get-Command dotnet -ErrorAction SilentlyContinue)) {
    throw "The 'dotnet' SDK CLI was not found on PATH. Install the .NET 10 SDK."
}

# --- Best-effort: read the shard build number from the runtime ShardVersion.cs (for display only) ---
$shard  = '(unknown)'
$svPath = Join-Path $RepoRoot 'Data\Scripts\System\Misc\ShardVersion.cs'
if (Test-Path $svPath) {
    $hit = Select-String -Path $svPath -Pattern 'Current\s*=\s*"([^"]+)"' | Select-Object -First 1
    if ($hit) { $shard = 'V#' + $hit.Matches[0].Groups[1].Value }
}

Write-Step "Secrets of Sosaria engine build  (shard $shard, .NET 10, config $Configuration)"
Write-Host "    Repo root : $RepoRoot"
Write-Host "    Project   : $Csproj"

# --- Optional clean ---
if ($Clean) {
    Write-Step 'Clean'
    foreach ($d in @((Join-Path $ScriptDir 'bin'), (Join-Path $ScriptDir 'obj'))) {
        if (Test-Path $d) { Remove-Item $d -Recurse -Force; Write-Ok "removed $d" }
    }
}

if (-not $Deploy) {
    # --- Compile-verify only: build to staging, never touch the live deployment ---
    Write-Step "Compile-verify (build -> $StageDir)"
    & dotnet build $Csproj -c $Configuration "-p:OutputPath=$StageDir" --nologo
    if ($LASTEXITCODE -ne 0) { throw "dotnet build FAILED (exit $LASTEXITCODE). Nothing was deployed." }
    Write-Ok 'Engine compiles clean on .NET 10. The live deployment was NOT touched.'
    Write-Host '    Stop the server and re-run with -Deploy to publish + deploy to the repo root.'
    return
}

# --- Deploy: publish framework-dependent, then copy the publish root files to the repo root ---
Write-Step "Publish (framework-dependent, win-x64) -> $PublishDir"

$running = @(Get-Process -Name 'World' -ErrorAction SilentlyContinue)
if ($running.Count -gt 0 -and -not $Force) {
    throw ("A running 'World' server process (PID " + $running[0].Id + ") was detected. " +
           'Stop the server before deploying, or pass -Force to override.')
}
if ($running.Count -gt 0 -and $Force) {
    Write-Note ('-Force: a World process is running (PID ' + $running[0].Id + '); files may be locked.')
}

if (Test-Path $PublishDir) { Remove-Item $PublishDir -Recurse -Force }
& dotnet publish $Csproj -c $Configuration -r win-x64 --self-contained false -o $PublishDir --nologo
if ($LASTEXITCODE -ne 0) { throw "dotnet publish FAILED (exit $LASTEXITCODE). Nothing was deployed." }
if (-not (Test-Path (Join-Path $PublishDir 'World.dll'))) { throw "publish succeeded but World.dll is missing in $PublishDir" }

Write-Step "Deploy -> $RepoRoot"

# Back up the existing live engine files.
foreach ($f in @($LiveExe, $LiveDll)) {
    if (Test-Path $f) { Copy-Item $f "$f.bak" -Force; Write-Ok ("backed up " + (Split-Path $f -Leaf) + " -> " + (Split-Path $f -Leaf) + ".bak") }
}

# Copy the publish ROOT FILES only (not the localization sub-folders cs\, de\, ... or runtimes\).
$copied = 0
foreach ($file in Get-ChildItem -Path $PublishDir -File) {
    Copy-Item $file.FullName (Join-Path $RepoRoot $file.Name) -Force
    $copied++
}
Write-Ok "deployed $copied file(s) to the repo root (World.exe/dll + deps/runtimeconfig + Roslyn etc.)"

$live = Get-Item $LiveDll
Write-Ok ('World.dll  {0:N0} bytes  {1:yyyy-MM-dd HH:mm:ss}' -f $live.Length, $live.LastWriteTime)

Write-Step 'Done'
Write-Host "    Next: start the server (startserver.bat). On first start it recompiles the runtime scripts"
Write-Host "    into Data.bin via Roslyn (hash changed), then prints '.NET 10.x' and the banner"
Write-Host "    'Secrets of Sosaria Shard $shard' just before it loads the world."
