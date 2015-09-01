using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using System.Text;

namespace ServerSnitch.Handlers
{
    class ServiceHandler
    {

        public void LogServices() 
        {
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

                serviceNames.Add("-----");

            }

            System.IO.File.WriteAllLines(@"C:\Users\Public\Services.txt", serviceNames);
        
        }




    }
}
