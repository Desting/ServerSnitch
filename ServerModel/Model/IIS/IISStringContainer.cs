using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataExtractor.Model.IIS
{
    public class IISStringContainer
    {
        public string IISVersion { get; set; }
        public List<Website> websites { get; set; }

        //[Key, ForeignKey("master")]
        //public int masterId { get; set; }
        //public virtual MasterEntity master { get; set; }


        public IISStringContainer(string IISVersion, List<Website> websites)
        {
            this.IISVersion = IISVersion;
            this.websites = websites;
        }

        public IISStringContainer()
        {
            this.websites = new List<Website>();
        }
        
    }
}
