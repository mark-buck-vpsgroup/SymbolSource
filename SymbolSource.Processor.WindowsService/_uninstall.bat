@echo off
@setlocal enableextensions
@cd /d "%~dp0"

set servicename="Symbol Source Processor"

C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe /u /servicename=%servicename% SymbolSource.Processor.WindowsService.exe
pause
