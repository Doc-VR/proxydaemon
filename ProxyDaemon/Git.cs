using System.Linq;
using Microsoft.Win32;
using System.Diagnostics;
using System;

namespace ProxyDaemon
{
    class Git
    {

        private static Process process;
        private static ProcessStartInfo startInfo;

       /*
        * Check if Git is installed on the system
        */
        public  static bool isInstalled()
        {
            var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall") ??
                      Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");

            if (key == null)
                return false;


            return key.GetSubKeyNames()
                .Select(keyName => key.OpenSubKey(keyName))
                .Select(subkey => subkey.GetValue("DisplayName") as string)
                .Any(displayName => displayName != null && displayName.Contains("Git"));
        }

        public static bool enableHTTPProxy()
        {
            Git.process = new Process();
            Git.startInfo = new ProcessStartInfo();
            Git.startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Git.startInfo.FileName = "git.exe";
            Git.startInfo.Arguments = "config --global http.proxy http://10.127.254.1:80";
            Git.process.StartInfo = Git.startInfo;
            Git.process.Start();
#if DEBUG
            Console.WriteLine("Git HTTP Proxy has been enabled");
#endif
            return true;
        }

        public static bool disableHTTPProxy()
        {
            Git.process = new Process();
            Git.startInfo = new ProcessStartInfo();
            Git.startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Git.startInfo.FileName = "git.exe";
            Git.startInfo.Arguments = "git config --global --unset http.proxy";
            Git.process.StartInfo = Git.startInfo;
            Git.process.Start();
#if DEBUG
            Console.WriteLine("Git HTTP Proxy has been disabled");
#endif
            return true;
        }
    }
}
