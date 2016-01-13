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
/// The main entry point for the application.
        static void Main()
        {
// Read the uri that is set in the App.config file. ("http://localhost:62273/api/ServerData")
            var uri = System.Configuration.ConfigurationManager.AppSettings["serviceURL"];

// Instantiate the PostController with proper uri
            PostController control = new PostController(uri);

// The PostController is the controller of the program, delegating tasks to the handlers
            control.ExtractAndSerializeData();
        }
    }
}
