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

int enableWindowsProxy()
{
	

	HKEY key;
	//const BYTE pData = 1;
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
					(BYTE*)"1",// 1 for enable
					sizeof(BYTE)
					) == ERROR_SUCCESS
		  ){ return 1; }
	}

	return 0;		
}
