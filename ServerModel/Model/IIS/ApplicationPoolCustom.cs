using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataExtractor.Model.IIS
{
   public class ApplicationPoolCustom
    {
        [Key, Column(Order = 2)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string poolName { get; set; }
        public List<string> directories { get; set; }


        [Key, ForeignKey("site"), Column(Order = 1)]
        public string siteName { get; set; }
        public virtual Website site { get; set; }

        //[Key, ForeignKey("site"), Column(Order = 0)]
        //public string masterId { get; set; }

        public ApplicationPoolCustom()
        {

        }

        public ApplicationPoolCustom(string poolName, List<string> directories)
        {
            this.poolName = poolName;
            this.directories = directories;
        }



    }
}
