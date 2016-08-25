#ifndef GIT_H
#define GIT_H

#include <stdio.h>
#include <windows.h>
#include <shellapi.h>

#pragma comment(lib,"Shell32.lib")

int isGitInstalled();
HINSTANCE enableHTTPProxy();
HINSTANCE disableHTTPProxy();

#endif
