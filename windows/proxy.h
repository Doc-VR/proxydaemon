#ifndef PROXY_H 
#define PROXY_H

#include <windows.h>
#include <stdio.h>

#define HTTP_PROXY "10.127.23.2"
#define PORT_PROXY 80

// My prototypes
int isWindowsProxyEnabled();
int enableWindowsProxy();
int disableWindowsProxy();

#endif
