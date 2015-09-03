using Newtonsoft.Json;
using ServerSnitch.Model;
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

        public List<ServiceData> ListServices() 
        {
            List<ServiceData> serviceList = new List<ServiceData>();


            ServiceController[] services = ServiceController.GetServices();
            foreach (var service in services)
            {
                ServiceData serviceData = new ServiceData();

                serviceData.displayName = service.DisplayName;
                serviceData.systemName = service.ServiceName;

                ManagementObject wmiService;
                wmiService = new ManagementObject("Win32_Service.Name='" + service.ServiceName + "'");
                wmiService.Get();

                if (wmiService["StartName"] != null)
                {
                    serviceData.logon = wmiService["StartName"].ToString();

                }
                else
                {
                    serviceData.logon = "";

                }


                if (wmiService["Description"] != null)
                {
                    serviceData.description = wmiService["Description"].ToString();
                }
                else
                {
                    serviceData.description = "";
                }
                serviceData.type = service.ServiceType.ToString();
                serviceData.status = service.Status.ToString();


                List<string> dependencies = new List<string>();

                ServiceController[] temp = service.ServicesDependedOn;
                if (temp.Length > 0)
                {
                    foreach (var x in temp)
                    {

                        dependencies.Add(x.ServiceName);
                    }
                }
                else
                {
                    dependencies.Add("None");
                }

                serviceData.dependencies = dependencies;

                serviceList.Add(serviceData);
            }
            return serviceList;
        
        }




    }
}
