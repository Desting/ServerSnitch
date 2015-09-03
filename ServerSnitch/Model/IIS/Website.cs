using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerSnitch.Model.IIS
{
    class Website
    {
        public string siteName { get; set; }
        public string state { get; set; }
        public string parentPool { get; set; }
        public List<string> bindings { get; set; }
        public List<ApplicationPoolCustom> applicationPools { get; set; }

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
