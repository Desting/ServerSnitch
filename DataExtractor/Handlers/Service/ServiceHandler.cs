using Newtonsoft.Json;
using DataExtractor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using System.Text;
using ServerModel.Model;

namespace DataExtractor.Handlers
{
    public class ServiceHandler : DataExtractor.Handlers.IServiceHandler
    {

        public List<ApplicationData> ListServices() 
        {
            List<ApplicationData> serviceList = new List<ApplicationData>();


            ServiceController[] services = ServiceController.GetServices();
            foreach (var service in services)
            {
                ApplicationData serviceData = new ApplicationData();

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


                List<Dependency> dependencies = new List<Dependency>();

                ServiceController[] temp = service.ServicesDependedOn;
                if (temp.Length > 0)
                {
                    foreach (var x in temp)
                    {
                        Dependency dep = new Dependency();
                        dep.name = x.ServiceName;
                        dependencies.Add(dep);
                    }
                }
                else
                {
                    Dependency dep = new Dependency();
                    dep.name = "None";
                    dependencies.Add(dep);
                }

                serviceData.dependencies = dependencies;

                serviceList.Add(serviceData);
            }
            return serviceList;
        
        }




    }
}
