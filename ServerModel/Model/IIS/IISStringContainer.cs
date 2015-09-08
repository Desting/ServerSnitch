using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataExtractor.Model.IIS
{
    public class IISStringContainer
    {
        public string IISVersion { get; set; }
        public List<Website> websites { get; set; }

        public IISStringContainer(string IISVersion, List<Website> websites)
        {
            this.IISVersion = IISVersion;
            this.websites = websites;
        }

        public IISStringContainer()
        {

        }
        
    }
}
