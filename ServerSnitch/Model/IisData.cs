using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSnitch.Model
{
    class IisData
    {

        string version;
        


        public Version IisVersion { get; set; }
        public ApplicationPoolCollection applicationPools { get; set; }
        public SiteCollection sites { get; set; }

        public IisData()
        {

        }

        public IisData(Version IisVersion, ApplicationPoolCollection applicationPools, SiteCollection sites)
        {
            this.IisVersion = IisVersion;
            this.applicationPools = applicationPools;
            this.sites = sites;
        }

        
    }
}
