﻿using Microsoft.Web.Administration;
using Microsoft.Win32;
using Newtonsoft.Json;
using ServerSnitch.Model;
using ServerSnitch.Model.IIS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSnitch.Handlers
{
    class IisHandler
    {


        public IISData CreateIisDataObject(ServerManager server, Version IisVersion)
        {
            ApplicationPoolCollection applicationPools = server.ApplicationPools;
            SiteCollection sites = server.Sites;

            IISData iis = new IISData(IisVersion, applicationPools, sites);

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

        public void StoreIIS(IISData iis)
        {

            IISStringContainer container = new IISStringContainer();

            // Store IIS Version
            container.IISVersion = iis.IisVersion.ToString();

            // Store Websites 
            List<Website> websites = ListWebsites(iis);
            container.websites = websites;


            string json = JsonConvert.SerializeObject(container);
            System.IO.File.WriteAllText(@"C:\Users\Public\jsonIIS.txt", json);

        }

        List<Website> ListWebsites(IISData iis) 
        {
            List<Website> websites = new List<Website>();

            foreach (Site site in iis.sites)
            {
                Website website = new Website();

                // Store the Name of the Site.
                website.siteName = site.ToString();

                // Store the State of the Site.
                website.state = site.State.ToString();


                // Get the list of all Bindings for this site.
                BindingCollection bindings = site.Bindings;
                List<String> bindingsList = ListBindings(bindings);

                // Store the Bindings.
                website.bindings = bindingsList;


                ApplicationDefaults defaults = site.ApplicationDefaults;

                // Get the name of the ApplicationPool under which the Site runs.
                string appPoolName = defaults.ApplicationPoolName;
                website.parentPool = appPoolName;


                // Get the list of all Applications for this Site.
                ApplicationCollection applications = site.Applications;
                List<ApplicationPoolCustom> custPools = ListApplicationPools(applications);

                website.applicationPools = custPools;
                websites.Add(website);

            }

            return websites;
        }

        List<ApplicationPoolCustom> ListApplicationPools(ApplicationCollection applications) 
        {
            List<ApplicationPoolCustom> pools = new List<ApplicationPoolCustom>();

            // Go through each Application.
            foreach (Microsoft.Web.Administration.Application application in applications)
            {
                ApplicationPoolCustom pool = new ApplicationPoolCustom();
                
                // Store Pool Name.
                pool.poolName = application.ApplicationPoolName;

                // Get all Directories associated.
                VirtualDirectoryCollection directories = application.VirtualDirectories;
                List<string> dirs = ListDirectivesNames(directories);

                // Store list of Directories.
                pool.directories = dirs;

                // Add Pool to list of Pools.
                pools.Add(pool);
            }

            return pools;
        }



        List<string> ListDirectivesNames(VirtualDirectoryCollection directories) 
        {
            List<string> dirs = new List<string>();

            // Go through each Directory.
            foreach (VirtualDirectory directory in directories)
            {
                // Store Directory Name.
                dirs.Add(directory.ToString());
            }
            return dirs;
        }

        List<string> ListBindings(BindingCollection bindings) 
        {
            List<string> binds = new List<string>();

            // Go through each Binding.
            foreach (Microsoft.Web.Administration.Binding binding in bindings)
            {
                // Store Binding name.
                binds.Add(binding.ToString());
            }

            return binds;
        }

        

    }
}
