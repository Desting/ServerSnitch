using Newtonsoft.Json;
using ServerSnitch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSnitch.Handlers
{
    class EnvironmentHandler
    {

        public void SerializeAndStore(EnvironmentData environment) 
        {
            string json = JsonConvert.SerializeObject(environment);
            System.IO.File.WriteAllText(@"C:\Users\Public\JSONEnvironment.txt", json);
        }

        public EnvironmentData GetEnvironmentData()
        {
            string machineName = Environment.MachineName;
            string domainName = Environment.UserDomainName.ToString();
            string userName = Environment.UserName;
            string osVersion = Environment.OSVersion.ToString();
            string logTime = DateTime.Now.ToLongDateString() + ", " + DateTime.Now.ToLongTimeString();
            EnvironmentData temp = new EnvironmentData(machineName, domainName, userName, osVersion, logTime);
            return temp;
        }
    }
}
