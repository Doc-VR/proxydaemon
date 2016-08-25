#include "proxy.h"

/*	
 * check if windows proxy system
 * is enabled.
 * @return value
 */
int isWindowsProxyEnabled()
{
	//char value[255];
	int value = 25;
	DWORD BufferSize = 8192;

	// read the value from reg key
	
	RegGetValue
		(
		 HKEY_CURRENT_USER,
		 "SOFTWARE\\MICROSOFT\\WINDOWS\\CurrentVersion\\Internet Settings",
		 "ProxyEnable",
		 //RRF_RT_ANY,
		 0x0000ffff,
		 NULL,
		 (PVOID)&value,
		 &BufferSize
		);
	

	return value;
}

/*
 * Enable Windows Proxy
 * return 1 if success, o if failed
 */
int enableWindowsProxy()
{
	

	HKEY key;
	DWORD value = 0x00000001;

	if(
			RegOpenKeyEx
			(
				HKEY_CURRENT_USER,
		 		"SOFTWARE\\MICROSOFT\\WINDOWS\\CurrentVersion\\Internet Settings",
		 		0,
		 		0xF003F, //All access
		 		&key
			) == ERROR_SUCCESS
	  )
	{
		if(
				RegSetValueEx(
					key,
					"ProxyEnable",
					0,
					REG_DWORD,
					(const BYTE*)&value,// 1 == enable
					sizeof(value)
					) == ERROR_SUCCESS
		  )
		{ 
			RegCloseKey(key);
			return 1;
	       	}
	}

	RegCloseKey(key);

	return 0;		
}

/*
 * disable Windows Proxy
 * return 1 if success, o if failed
 */
int disableWindowsProxy()
{
	

	HKEY key;
	DWORD value = 0x00000000;

	if(
			RegOpenKeyEx
			(
				HKEY_CURRENT_USER,
		 		"SOFTWARE\\MICROSOFT\\WINDOWS\\CurrentVersion\\Internet Settings",
		 		0,
		 		0xF003F, //All access
		 		&key
			) == ERROR_SUCCESS
	  )
	{
		if(
				RegSetValueEx(
					key,
					"ProxyEnable",
					0,
					REG_DWORD,
					(const BYTE*)&value,// 0 == disable
					sizeof(value)
					) == ERROR_SUCCESS
		  )
		{ 
			RegCloseKey(key);
			return 1;
	        }

	}

	RegCloseKey(key);
	return 0;		
}
