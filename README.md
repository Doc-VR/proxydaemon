# Proxy Daemon

It's a CLI tool written in C for Windows and soon for linux, it works as a daemon service ( under the hood ), it enables and disables automaticly **PROXY** settings on you systems
and some programs such as GIT.

## How it works 

The program detects and checks the range of your IP, if the IP matchs with the one of your entreprise IP, it sets the proxy of your entreprise.  

## How To Compile

If you are under Windows, the easy way to create an executable is to create a new C project on Dev-c++ and copy files to your  project then compile it.   
The second wich I used is to install Microsoft Visual Studio Community and Windows SDK then sat environement variables manually.

Add to PATH:  

* C:\Program Files\Microsoft SDKs\Windows\v7.1A\Bin
* C:\Program Files\Microsoft Visual Studio 14.0\VC\Bin
* C:\Program Files\Microsoft Visual Studio 14.0\Common7\IDE

Add to INCLUDE:  

* C:\Program Files\Microsoft SDKs\Windows\v7.1A\Include
* C:\Program Files\Microsoft Visual Studio 14.0\VC\include
* C:\Program Files\Microsoft Visual Studio 9.0\VC\atlmfc\include

Add to LIB:  

* C:\Program Files\Microsoft SDKs\Windows\v7.1A\Lib
* C:\Program Files\Microsoft Visual Studio 14.0\VC\lib  

Now you can run build.bat to compile your code 

## How To Install 

Run install.bat if you are under Windows, the script copies the executable file to the user startup folder  then execute it 


## To Do

* add among others NPM (nodejs) functionalty to  the  program
* make Entreprise IP customizable

