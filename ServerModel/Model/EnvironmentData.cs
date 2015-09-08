using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractor.Model
{
    
    public class EnvironmentData
    {
        
        public string machineName { get; set; }
        public string domainName { get; set; }
        public string userName { get; set; }
        public string osVersion { get; set; }
        public string logTime { get; set; }

        public bool hasIis { get; set; }
        //public bool hasDatabase { get; set; }
        //public bool hasApplication { get; set; }

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
            values.Add("");
            values.Add("Machine name: ");
            values.Add(machineName);
            values.Add("");

            values.Add("Domain name: ");
            values.Add(domainName);
            values.Add("");
            values.Add("User name: ");
            values.Add(userName);
            values.Add("");
            values.Add("OS Version: ");
            values.Add(osVersion);
            values.Add("");
            values.Add("LogTime: ");
            values.Add(logTime);
            values.Add("");
            values.Add("Has IS: ");
            values.Add(hasIis.ToString());


            return values;
        }
    }
}
