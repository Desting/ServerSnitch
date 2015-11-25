using DataExtractor.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ServerModel
{
   public class Tag
    {
       [Key]
       public string title { get; set; }

       public virtual ICollection<MasterEntity> servers { get; set; }

       public Tag(string title) 
       {
           this.title = title;
       }
    }
}
