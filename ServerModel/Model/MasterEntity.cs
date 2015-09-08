using DataExtractor.Model.IIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataExtractor.Model
{
    public class MasterEntity
    {
        public EnvironmentData environment { get; set; }
        public IISStringContainer iis { get; set; }
        public List<ServiceData> applications { get; set; }
        public List<string> databases { get; set; }

        public MasterEntity()
        {

        }

        public MasterEntity(EnvironmentData environment, IISStringContainer iis, List<ServiceData> applications, List<string> databases)
        {
            this.environment = environment;
            this.iis = iis;
            this.applications = applications;
            this.databases = databases;

        }

    }
}
