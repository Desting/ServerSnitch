using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSnitch.Model
{
    class EnvironmentData
    {
        public string machineName { get; set; }
        public string domainName { get; set; }
        public string userName { get; set; }
        public string osVersion { get; set; }
        public string logTime { get; set; }

        public bool hasIis { get; set; }
        public bool hasDatabase { get; set; }
        public bool hasApplication { get; set; }

        public EnvironmentData(string machineName, string domainName, string userName, string osVersion, string logTime)
        {
            this.machineName = machineName;
            this.domainName = domainName;
            this.userName = userName;
            this.osVersion = osVersion;
            this.logTime = logTime;
        }

        public List<string> GetAllValues()
        {
            List<string> values = new List<string>();
            values.Add("GENERAL INFORMATION:");
            values.Add("Machine name: " + machineName);
            values.Add("Domain name: " + domainName);
            values.Add("User name: " + userName);
            values.Add("OS Version: " + osVersion);
            values.Add("LogTime: " + logTime);
            values.Add("Has IS: " + hasIis.ToString());


            return values;
        }
    }
}
