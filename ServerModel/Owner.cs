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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string name { get; set; }
        public string initials { get; set; }
        public string email { get; set; }

        public Owner() 
        {
        }

        public Owner(string name, string initials, string email)
        {
            this.name = name;
            this.initials = initials;
            this.email = email;
        }

    }
}
