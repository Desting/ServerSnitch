using DataExtractor.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var uri = System.Configuration.ConfigurationManager.AppSettings["serviceURL"];
            Controller control = new Controller(uri);
            control.ExtractAndSerializeData();

            
        }
    }
}
