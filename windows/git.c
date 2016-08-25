#include "git.h"

/*
 * Check if GitForWindows is Installed
 * return 1 if installed, 0 if not
 */

int isGitInstalled()
{
	HKEY hkey;

	int ret = RegOpenKeyEx(
			HKEY_LOCAL_MACHINE,
			"SOFTWARE\\GitForWindows",
			0,
			0xF003F,
			&hkey
			);
	
	if(ret == ERROR_SUCCESS)
	{
		RegCloseKey(hkey);
		return 1;
	}
	else
	{
		RegCloseKey(hkey);
		return 0;
	}
}

HINSTANCE enableHTTPProxy()
{
	return ShellExecute(
			NULL,
			"open",
			"git.exe",
			"config --global http.proxy http://10.127.254.1:80",
			NULL,
			SW_HIDE
			);
}

HINSTANCE disableHTTPProxy()
{
	return ShellExecute(
			NULL,
			"open",
			"git.exe",
			"config --global --unset http.proxy",
			NULL,
			SW_HIDE
			);
}
