using DataExtractor.Model.IIS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataExtractor.Model
{
    public class MasterEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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
