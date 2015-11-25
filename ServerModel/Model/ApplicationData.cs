using ServerModel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataExtractor.Model
{
    public class ApplicationData
    {
        [Key, Column(Order=1)]
        public string systemName { get; set; }

        [Key, ForeignKey("master"), Column(Order=0)]
        public string masterId { get; set; }
        public virtual MasterEntity master { get; set; }
        public string displayName { get; set; }
        public string logon { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public List<Dependency> dependencies { get; set; }


    }
}
