using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractor.Model
{
    
    public class EnvironmentData
    {
        [Key, ForeignKey("master")]
        public string machineName { get; set; }
        public virtual MasterEntity master { get; set; }

        public string domainName { get; set; }
        public string userName { get; set; }
        public string osVersion { get; set; }
        public DateTime logTime { get; set; }

        public bool hasIis { get; set; }
        public EnvironmentData()
        {
        }

        public EnvironmentData(string machineName, string domainName, string userName, string osVersion, DateTime logTime)
        {
            this.machineName = machineName;
            this.domainName = domainName;
            this.userName = userName;
            this.osVersion = osVersion;
            this.logTime = logTime;
        }
    }
}
