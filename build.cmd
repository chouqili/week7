@echo off
rem Builds the seven Exercise programs. This wrapper is here because Windows
rem blocks unsigned PowerShell scripts on many machines by default.
powershell -NoProfile -ExecutionPolicy Bypass -File "%~dp0build.ps1" %*
