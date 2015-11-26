using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataExtractor.Model.IIS
{
    public class Website
    {
        [Key, Column(Order = 1)]
        public string siteName { get; set; }
        public string state { get; set; }
        public string parentPool { get; set; }
        public List<string> bindings { get; set; }
        public List<ApplicationPoolCustom> applicationPools { get; set; }

        [Key, ForeignKey("iis"), Column(Order = 0)]
        public string masterId { get; set; }
        public virtual IISStringContainer iis { get; set; }

        //[Key, ForeignKey("master"), Column(Order = 0)]
        //public string masterId { get; set; }
        //public virtual MasterEntity master { get; set; }

        

        public Website()
        {

        }

        public Website(string siteName, string state, string parentPool, List<string> bindings, List<ApplicationPoolCustom> applicationPools)
        {
            this.siteName = siteName;
            this.state = state;
            this.parentPool = parentPool;
            this.bindings = bindings;
            this.applicationPools = applicationPools;
        }

    }
}
