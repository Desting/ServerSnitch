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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string poolName { get; set; }
        public List<string> directories { get; set; }


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
