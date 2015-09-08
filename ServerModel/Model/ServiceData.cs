using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataExtractor.Model
{
    public class ServiceData
    {
        public string displayName { get; set; }
        public string systemName { get; set; }
        public string logon { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public List<string> dependencies { get; set; }


    }
}
