@echo off
echo compiling...
cl /Fe:"proxyDaemon.exe" *.c 
echo clean up
del *.obj
REM I am using VIM so ...
del *.~
