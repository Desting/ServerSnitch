using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSnitch.Model
{
    class IISData
    {
        

        //List<> sites;
        //Site:
        //name
        //state
        //parentPool
        //List<> bindings
        //    bindingName;
        //List<> applicationPools
        //    poolName
        //    List<> directories 
        //        directoryName
        


        public Version IisVersion { get; set; }
        public ApplicationPoolCollection applicationPools { get; set; }
        public SiteCollection sites { get; set; }

        public IISData()
        {

        }

        public IISData(Version IisVersion, ApplicationPoolCollection applicationPools, SiteCollection sites)
        {
            this.IisVersion = IisVersion;
            this.applicationPools = applicationPools;
            this.sites = sites;
        }

        
    }
}
