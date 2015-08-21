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
            List<String> testList = new List<string>();
            List<String> appliPools = new List<string>();

            foreach (Site site in iis.sites)
            {
                //siteNames.Add(site.ToString());
                appliPools.Add("SITE: ");
                appliPools.Add(site.ToString());
                appliPools.Add("");

                ObjectState siteState = site.State;
                appliPools.Add("STATE: ");
                appliPools.Add(siteState.ToString());
                appliPools.Add("");

                appliPools.Add("BINDINGS: ");
                BindingCollection bindings = site.Bindings;
                foreach (Microsoft.Web.Administration.Binding binding in bindings)
                {
                    appliPools.Add(binding.ToString());
                }
                appliPools.Add("");

                ApplicationDefaults defaults = site.ApplicationDefaults;

                //get the name of the ApplicationPool under which the Site runs
                string appPoolName = defaults.ApplicationPoolName;
                appliPools.Add("PARENT POOL:");
                appliPools.Add(appPoolName);
                appliPools.Add("");


                appliPools.Add("APPLICATION POOLS: ");
                appliPools.Add("");
                appliPools.Add("----");

                //Get the list of all Applications for this Site
                ApplicationCollection applications = site.Applications;
                foreach (Microsoft.Web.Administration.Application application in applications)
                {
                    appliPools.Add("POOL: ");

                    //get the name of the ApplicationPool
                    string applicationPoolName = application.ApplicationPoolName;
                    appliPools.Add(applicationPoolName);
                    appliPools.Add("");


                    appliPools.Add("DIRECTORIES: ");

                    VirtualDirectoryCollection directories = application.VirtualDirectories;
                    foreach (VirtualDirectory directory in directories)
                    {
                        appliPools.Add(directory.ToString());
                        //put code here to work with each VirtualDirectory
                    }
                    appliPools.Add("");
                    appliPools.Add("----");
                    appliPools.Add("");

                }
                appliPools.Add("");
                appliPools.Add("---------------------------------------");
                appliPools.Add("");
            }

            System.IO.File.WriteAllLines(@"C:\Users\Public\Sites.txt", appliPools);

        }

    }
}
