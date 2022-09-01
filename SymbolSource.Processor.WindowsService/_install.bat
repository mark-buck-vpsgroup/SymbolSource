@echo off
@setlocal enableextensions
@cd /d "%~dp0"

set servicename="Symbol Source Processor"

C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe /u /servicename=%servicename% SymbolSource.Processor.WindowsService.exe
pause

C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe /servicename=%servicename% /displayname=%servicename% /username=HG_DOMAIN\svcDevDeploy /password="Br0kenB00k!" SymbolSource.Processor.WindowsService.exe
pause


