using DataExtractor.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ServerModel
{
    public class Owner
    {
        [Key]
        public string Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public virtual ICollection<MasterEntity> servers { get; set; }


        public Owner() 
        {
        }

        public Owner(string Id, string name, string email)
        {
            this.name = name;
            this.Id = Id;
            this.email = email;
        }

    }
}
