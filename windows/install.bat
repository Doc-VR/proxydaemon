@echo off
echo compiling...
cl /Fe:"proxyDaemon.exe" *.c 
echo Copying file to data folder
xcopy /y proxyDaemon.exe %APPDATA%"\Microsoft\Windows\Start Menu\Programs\Startup\"
echo Starting Proxy Daemon
start proxyDaemon.exe
echo clean up
del *.obj
REM I am using VIM so ...
del *.~
