using System;
using System.Net;
using Microsoft.Win32;


namespace ProxyDaemon
{
    class Program
    {
        static void Main(string[] args)
        {

           

            // get local ip adress 
            var host = Dns.GetHostEntry(Dns.GetHostName());

            // listing all ip addresses under the system
            foreach (var ip in host.AddressList)
            {
                // ip v4
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    // check if the ip equals to the ip address of entreprise proxy 
                    // 192.168.0.39*
                    // 10.121.61.145 my current AFPA IP
                    if (ip.ToString().Contains("10.121"))
                    {
#if DEBUG
                        Console.WriteLine("AFPA proxy IP has been detected ");
#endif

                        if (Proxy.isProxyActivated() == false)
                        {
                            Proxy.enableProxy();

                            if (!Git.isInstalled())
                            {
                                if (Git.enableHTTPProxy()) Console.WriteLine("Git Http.proxy ON");
                            }

                          
                        }
                        else
                        {
#if DEBUG
                            Console.WriteLine("Proxy already enabled");
#endif
                        }
                        
                    }
                    else
                    {
                        if (Proxy.isProxyActivated() == true)
                        {
                            Proxy.disableProxy();

                            if (Git.isInstalled())
                            {
                                if(Git.disableHTTPProxy()) Console.WriteLine("Git Http.proxy OFF");
                            }

                        
                        }
                        else
                        {
#if DEBUG
                            Console.WriteLine("Proxy already disabled");
#endif
                        }
                    }
                }
            } 
        }

    }

}
