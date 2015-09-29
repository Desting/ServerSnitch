using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataExtractor.Model
{
    public class ServiceData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string displayName { get; set; }
        public string systemName { get; set; }
        public string logon { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public List<string> dependencies { get; set; }


    }
}
