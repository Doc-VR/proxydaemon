@echo off
echo Copying file to data folder
xcopy /y proxyDaemon.exe %APPDATA%"\Microsoft\Windows\Start Menu\Programs\Startup\"
echo Starting Proxy Daemon
start proxyDaemon.exe
echo Installation Success !
