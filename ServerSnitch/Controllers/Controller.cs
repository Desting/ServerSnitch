using Microsoft.Web.Administration;
using ServerSnitch.Handlers;
using ServerSnitch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSnitch.Controllers
{
    class Controller
    {
        public void Run()
        {
            //Initialize handlers
            IisHandler iisHandler = new IisHandler();
            EnvironmentHandler envHandler = new EnvironmentHandler();

            //Initialize server manager
            ServerManager server = new ServerManager();

            EnvironmentData environment = envHandler.GetEnvironmentData();

            Version iisVersion = iisHandler.GetIisVersion(environment);

            List<string> values = environment.GetAllValues();
            System.IO.File.WriteAllLines(@"C:\Users\Public\Environment.txt", values);

            if (environment.hasIis)
            {
                //Write it to file

               IisData iis = iisHandler.CreateIisDataObject(server, iisVersion);
                iisHandler.logWebsitesAndPools(iis);


            }

            if (environment.hasApplication)
            {
                //Write it to file
            }

            if (environment.hasDatabase)
            {
                //Write it to file
            }


        }

    }
}
