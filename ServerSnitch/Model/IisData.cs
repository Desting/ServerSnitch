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

        public List<string> GetAllValues()
        {
            List<string> values = new List<string>();
            values.Add("SITES:");
            foreach (Site site in sites)
            {
                ApplicationCollection applications = site.Applications;
                foreach (Microsoft.Web.Administration.Application application in applications)
                {
                    //get the name of the ApplicationPool
                    string applicationPoolName = application.ApplicationPoolName;
                    values.Add(applicationPoolName);
                }
            }


            return values;
        }
    }
}
