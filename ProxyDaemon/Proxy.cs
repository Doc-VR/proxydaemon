using System;
using Microsoft.Win32;

namespace ProxyDaemon
{
    class Proxy
    {

        /*
        * return true if proxy is ON, false if not
        * 0 means proxy is off
        * 1 means proxy is on
        */
        public static bool isProxyActivated()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);
            int proxyStatus = (int)key.GetValue("ProxyEnable");
            return (proxyStatus == 1) ? true : false;
        }

        public static bool enableProxy()
        {
             if(Proxy.isProxyActivated() == false)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);
                key.SetValue("ProxyEnable", 1);
#if DEBUG
                Console.WriteLine("Windows proxy has been enabled");
#endif
                return true;
            }
            else
            {
#if DEBUG
                Console.WriteLine("Windows proxy has been enabled");
#endif
                return true;
            }
        }


        public static bool disableProxy()
        {
            if (Proxy.isProxyActivated() == true)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);
                key.SetValue("ProxyEnable", 0);
#if DEBUG
                Console.WriteLine("Windows proxy has been disabled");
#endif
                return true;
            }
            else
            {
#if DEBUG
                Console.WriteLine("Windows proxy has been disabled");
#endif
                return true;
            }
        }


    }
}
