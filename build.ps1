# Builds the seven Exercise programs with the C# compiler that ships with
# Windows (.NET Framework), so no SDK or Visual Studio is needed to run them.
#
#   .\build.ps1            builds every exercise into .\bin
#   .\build.ps1 -Clean     removes .\bin first
#
# The programs are plain console applications; the same source files compile
# unchanged in a Visual Studio Console Application project.

[CmdletBinding()]
param(
    [switch] $Clean
)

$ErrorActionPreference = 'Stop'

$compiler = Join-Path $env:WINDIR 'Microsoft.NET\Framework64\v4.0.30319\csc.exe'

if (-not (Test-Path $compiler)) {
    $compiler = Join-Path $env:WINDIR 'Microsoft.NET\Framework\v4.0.30319\csc.exe'
}

if (-not (Test-Path $compiler)) {
    throw 'The .NET Framework C# compiler (csc.exe) was not found. Install .NET Framework 4.x or use Visual Studio.'
}

$bin = Join-Path $PSScriptRoot 'bin'

if ($Clean -and (Test-Path $bin)) {
    Remove-Item -Path $bin -Recurse -Force
}

New-Item -ItemType Directory -Path $bin -Force | Out-Null

$exercises = @(
    @{ Name = 'Exercise01_ForLoop';                 Files = @('Exercises\Exercise01_ForLoop\Program.cs') }
    @{ Name = 'Exercise02_WhileLoop';               Files = @('Exercises\Exercise02_WhileLoop\Program.cs') }
    @{ Name = 'Exercise03_DoWhileLoop';             Files = @('Exercises\Exercise03_DoWhileLoop\Program.cs') }
    @{ Name = 'Exercise04_DivisibleByThreeAndFour'; Files = @('Exercises\Exercise04_DivisibleByThreeAndFour\Program.cs') }
    @{ Name = 'Exercise05_EndlessDoWhile';          Files = @('Exercises\Exercise05_EndlessDoWhile\Program.cs') }
    @{ Name = 'Exercise06_Car';                     Files = @('Exercises\Exercise06_Car\Car.cs', 'Exercises\Exercise06_Car\Program.cs') }
    @{ Name = 'Exercise07_Calculator';              Files = @('Exercises\Exercise07_Calculator\Calculator.cs', 'Exercises\Exercise07_Calculator\Program.cs') }
)

foreach ($exercise in $exercises) {

    $sources = foreach ($file in $exercise.Files) {
        $path = Join-Path $PSScriptRoot $file

        if (-not (Test-Path $path)) {
            throw "Missing source file: $file"
        }

        $path
    }

    $target = Join-Path $bin ($exercise.Name + '.exe')

    & $compiler /nologo /target:exe /out:$target $sources

    if ($LASTEXITCODE -ne 0) {
        throw "Build failed: $($exercise.Name)"
    }

    Write-Host ("built  bin\{0}.exe" -f $exercise.Name)
}

Write-Host ''
Write-Host 'Run an exercise with, for example:'
Write-Host '  .\bin\Exercise01_ForLoop.exe'
Write-Host '  .\bin\Exercise07_Calculator.exe'
