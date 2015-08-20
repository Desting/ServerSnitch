using Microsoft.Web.Administration;
using Microsoft.Win32;
using ServerSnitch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSnitch.Handlers
{
    class IisHandler
    {

        public IisData CreateIisDataObject(ServerManager server, Version IisVersion) 
        {
            ApplicationPoolCollection applicationPools = server.ApplicationPools;
            SiteCollection sites = server.Sites;

            IisData iis = new IisData(IisVersion, applicationPools, sites);

            return iis;
        }

        public Version GetIisVersion(EnvironmentData environment)
        {
            using (RegistryKey componentsKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\InetStp", false))
            {
                if (componentsKey != null)
                {
                    int majorVersion = (int)componentsKey.GetValue("MajorVersion", -1);
                    int minorVersion = (int)componentsKey.GetValue("MinorVersion", -1);

                    if (majorVersion != -1 && minorVersion != -1)
                    {
                        environment.hasIis = true;
                        return new Version(majorVersion, minorVersion);
                    }
                }
                environment.hasIis = false;
                return new Version(0, 0);
            }
        }

        public void logWebsitesAndPools(IisData iis)
        {
            //List<String> siteNames = new List<string>();
            List<String> sitePoolConnection = new List<string>();
            List<String> appliPools = new List<string>();

            foreach (Site site in iis.sites)
            {
                //siteNames.Add(site.ToString());
                appliPools.Add("SITE: ");
                appliPools.Add(site.ToString());
                appliPools.Add("");


                ApplicationDefaults defaults = site.ApplicationDefaults;

                //get the name of the ApplicationPool under which the Site runs
                string appPoolName = defaults.ApplicationPoolName;
                appliPools.Add("PARENT:");
                appliPools.Add(appPoolName);
                appliPools.Add("");


                appliPools.Add("APPLICATION POOLS: ");


                //Get the list of all Applications for this Site
                ApplicationCollection applications = site.Applications;
                foreach (Microsoft.Web.Administration.Application application in applications)
                {
                    //get the name of the ApplicationPool
                    string applicationPoolName = application.ApplicationPoolName;
                    appliPools.Add(applicationPoolName);
                }
                appliPools.Add("");
                appliPools.Add("---------------------------------------");
                appliPools.Add("");
            }

            System.IO.File.WriteAllLines(@"C:\Users\Public\Sites.txt", appliPools);

        }

    }
}
