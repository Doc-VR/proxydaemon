@echo off
title=Proxy Deamon Installation
echo Copying file to Start Up folder
xcopy /y proxyDaemon.exe %APPDATA%"\Microsoft\Windows\Start Menu\Programs\Startup\"
echo Starting Proxy Daemon
start proxyDaemon.exe
echo Installation Success !

pause
