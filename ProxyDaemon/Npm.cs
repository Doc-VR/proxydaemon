using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Win32;
using System.Management;

namespace ProxyDaemon
{
    class Npm
    {
        private static string Path;
        private static Process process;
        private static ProcessStartInfo startInfo;


        /*
     * Check if Npm is installed on the system
     */
        public static bool isInstalled()
        {
            var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall") ??
                      Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");

            if (key == null)
                return false;

            return key.GetSubKeyNames()
                .Select(keyName => key.OpenSubKey(keyName))
                .Select(subkey => subkey.GetValue("DisplayName") as string)
               //.Select(subkey => subkey.GetValue("InstallLocation") as string )
                .Any(displayName => displayName != null && displayName.Contains("Node.js")); //Todo
        }

        /*
         *  Get file path
         * 
         * */

        public static string filePath()
        {
           
            if(Npm.isInstalled())
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Product");
                foreach (ManagementObject mo in mos.Get())
                {
                    if(mo["Name"].ToString().Contains("Node.js"))
                    {
#if DEBUG
                        if (mo["InstallLocation"]  != null)
                            Console.WriteLine("Npm path:" + mo["InstallLocation"].ToString());
                        else
                            Console.WriteLine("Npm path return Null");
#endif
                        return mo["InstallLocation"].ToString();
                    }
                    //Debug.Print(mo["Name"].ToString() + "," + mo["InstallLocation"].ToString() + Environment.NewLine);
                }
            }

            return string.Empty;
            /*
            var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall") ??
                      Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");

            if (key != null)
            {
                foreach(string keyName in key.GetSubKeyNames())
                {
                    RegistryKey subkey = key.OpenSubKey(keyName);
                    string progamName = subkey.GetValue("Node.js") as string;

                }
            }
            else { return string.Empty; }  // return empty string

    */

        }

        public static bool enableHTTPProxy()
        {
            Npm.process = new Process();
            Npm.startInfo = new ProcessStartInfo();
            Npm.startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Npm.startInfo.FileName = "C:\\Program Files\\nodejs\\npm.cmd";
            Npm.startInfo.Arguments = "config set proxy \"http://10.127.254.1:80\"";
            Npm.process.StartInfo = Npm.startInfo;
            Npm.process.Start();
#if DEBUG
            Console.WriteLine("Npm HTTP Proxy has been enabled");
#endif
            return true;
        }

        public static bool disableHTTPProxy()
        {
            Npm.process = new Process();
            Npm.startInfo = new ProcessStartInfo();
            Npm.startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Npm.startInfo.FileName = "C:\\Program Files\\nodejs\\npm.cmd";
            Npm.startInfo.Arguments = "config delete proxy";
            Npm.process.StartInfo = Npm.startInfo;
            Npm.process.Start();
#if DEBUG
            Console.WriteLine("Npm HTTP Proxy has been enabled");
#endif
            return true;
        }
    }
}
