@echo off
REM Powershell.exe -executionpolicy remotesigned -File proxyDaemonService.ps1
echo Copying file to data folder
xcopy proxyDaemon.exe %APPDATA%"\Microsoft\Windows\Start Menu\Programs\Startup\"
echo Starting Proxy Daemon
start proxyDaemon.exe

