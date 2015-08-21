using Microsoft.Web.Administration;
using ServerSnitch.Handlers;
using ServerSnitch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServerSnitch.Controllers
{
    class Controller
    {
        public void Run()
        {
            //Initialize handlers
            IisHandler iisHandler = new IisHandler();
            EnvironmentHandler envHandler = new EnvironmentHandler();

            //Initialize server manager
            ServerManager server = new ServerManager();

            EnvironmentData environment = envHandler.GetEnvironmentData();

            Version iisVersion = iisHandler.GetIisVersion(environment);

            List<string> values = environment.GetAllValues();
            System.IO.File.WriteAllLines(@"C:\Users\Public\Environment.txt", values);

            if (environment.hasIis)
            {
                //Write it to file

               IisData iis = iisHandler.CreateIisDataObject(server, iisVersion);
                iisHandler.logWebsitesAndPools(iis);


            }
            List<string> serviceNames = new List<string>();
            serviceNames.Add("SERVICES:");
            serviceNames.Add("");


            ServiceController[] services = ServiceController.GetServices();
            foreach (var service in services) 
            {

                serviceNames.Add("DISPLAY NAME:");
                serviceNames.Add(service.DisplayName);
                serviceNames.Add("");
                
             

            serviceNames.Add("NAME:");
            serviceNames.Add(service.ServiceName);
            serviceNames.Add("");


            ManagementObject wmiService;
            wmiService = new ManagementObject("Win32_Service.Name='" + service.ServiceName + "'");
            wmiService.Get();

            serviceNames.Add("LOG ON AS:");
            if (wmiService["StartName"] != null)
                {
                    serviceNames.Add(wmiService["StartName"].ToString());
                
                }
                else
                {
                    serviceNames.Add("-");

                }


            serviceNames.Add("");




            serviceNames.Add("DESCRIPTION:");
            if (wmiService["Description"] != null)
            {
                serviceNames.Add(wmiService["Description"].ToString());
            }
            else 
            {
                serviceNames.Add("-");
            }
            serviceNames.Add("");

            serviceNames.Add("TYPE:");
            serviceNames.Add(service.ServiceType.ToString());
            serviceNames.Add("");

            serviceNames.Add("STATUS:");
            serviceNames.Add(service.Status.ToString());
            serviceNames.Add("");

            serviceNames.Add("DEPENDS ON:");

            ServiceController[] temp = service.ServicesDependedOn;

            if (temp.Length > 0)
            {
                foreach (var x in temp)
                {
                    serviceNames.Add(x.ServiceName);
                }
            }
            else 
            {
                serviceNames.Add("Nothing");
            }
            serviceNames.Add("");


                
            
            //serviceNames.Add(service.ServicesDependedOn.ToString());
            //serviceNames.Add("");

            serviceNames.Add("-----");
                
            }

            System.IO.File.WriteAllLines(@"C:\Users\Public\Services.txt", serviceNames);


            if (environment.hasApplication)
            {
                //Write it to file
            }

            if (environment.hasDatabase)
            {
                //Write it to file
            }


            ServiceController[] scServices;
            scServices = ServiceController.GetServices();

            // Display the list of services currently running on this computer.

            Console.WriteLine("Services running on the local computer:");
            foreach (ServiceController scTemp in scServices)
            {
                if (scTemp.Status == ServiceControllerStatus.Running)
                {
                    // Write the service name and the display name 
                    // for each running service.
                    Console.WriteLine();
                    Console.WriteLine("  Service :        {0}", scTemp.ServiceName);
                    Console.WriteLine("    Display name:    {0}", scTemp.DisplayName);

                    // Query WMI for additional information about this service. 
                    // Display the start name (LocalSytem, etc) and the service 
                    // description.
                    ManagementObject wmiService;
                    wmiService = new ManagementObject("Win32_Service.Name='" + scTemp.ServiceName + "'");
                    wmiService.Get();
                    Console.WriteLine("    Start name:      {0}", wmiService["StartName"]);
                    Console.WriteLine("    Description:     {0}", wmiService["Description"]);
                }
            }


        }

    }
}
