using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerSnitch.Model.IIS
{
    class ApplicationPoolCustom
    {
        //    poolName
        //    List<> directories 
        //        directoryName
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
