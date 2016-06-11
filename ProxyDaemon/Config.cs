using System;
using System.Xml.Linq;


namespace ProxyDaemon
{
   
    public class Config
    {

        private XDocument configFile;
        private string ip;

        public Config()
        {
            try
            {
                this.configFile = XDocument.Load("config.xml");
                var IpXml = configFile.Descendants("ip");

                if(IpXml != null)
                {
                    foreach(var v in IpXml)
                    {
                        this.ip = v.Value;
                    }
                }
            }
            catch(SystemException e)
            {
#if DEBUG
                Console.WriteLine();
#endif
            }
            
        }

        public string getIP() { return this.ip; }

    }
}
