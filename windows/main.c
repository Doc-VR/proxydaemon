#ifndef WIN32_LEAN_AND_MEAN
#define WIN32_LEAN_AND_MEAN
#endif

#include<winsock2.h>
#include<stdio.h>

#include "proxy.h"
#include "git.h"

#pragma comment(lib,"ws2_32.lib")

int isAFPAIp();

int main()
{
	WSADATA wsaData;

	if(WSAStartup(MAKEWORD(2,2), &wsaData) != 0)
		return 999;
		

	// if IP AFPA and Windows Proxy OFF 
	if(isAFPAIp() > 0 && isWindowsProxyEnabled() < 1)
	{
		if(enableWindowsProxy() == 1)
			printf("windows proxy has been enabled\n");
	}
	else
		printf("fsdfsdfsdfs\n");

	WSACleanup();
	return 1;
}

int isAFPAIp()
{
	char value[80];
	int i;

	// Get Systeme hostname
	if(gethostname(value,sizeof(value)) == SOCKET_ERROR)
		return -1;

	struct hostent *host = gethostbyname(value);
	if(host == 0)
		return -2; // bad host lookup

	for(i=0; host->h_addr_list[i] != 0; ++i)
	{
		struct in_addr addr;
		memcpy(&addr, host->h_addr_list[i], sizeof(struct in_addr));

		if(strstr(inet_ntoa(addr), "10.121") != NULL)
			return 1;

	}

	return 0;
}
