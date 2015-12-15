using DataExtractor.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ServerModel.Model
{
   public class Dependency
    {
       [Key, Column(Order = 2)]
       public string name { get; set; }

       [Key, ForeignKey("application"), Column(Order = 1)]
       public string applicationId { get; set; }
       public virtual ServiceData application { get; set; }

       [Key, ForeignKey("application"), Column(Order = 0)]
       public string masterId { get; set; }

    }
}
