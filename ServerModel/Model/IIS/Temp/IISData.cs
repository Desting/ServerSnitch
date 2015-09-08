using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractor.Model
{
    public class IISData
    {
        

        public Version IisVersion { get; set; }
        public SiteCollection sites { get; set; }

        public IISData()
        {

        }

        public IISData(Version IisVersion,  SiteCollection sites)
        {
            this.IisVersion = IisVersion;
            this.sites = sites;
        }

        
    }
}
