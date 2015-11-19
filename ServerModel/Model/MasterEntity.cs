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
        public List<ApplicationData> applications { get; set; }
        public int cost { get; set; }

        public MasterEntity()
        {
        }

        public MasterEntity(EnvironmentData environment, IISStringContainer iis, List<ApplicationData> applications)
        {
            this.environment = environment;
            this.iis = iis;
            this.applications = applications;

        }

    }
}
