using Microsoft.Web.Administration;
using Newtonsoft.Json;
using ServerSnitch.Handlers;
using ServerSnitch.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerSnitch.Controllers
{
    class Controller
    {
        
        public void Run()
        {
            // Initialize handlers
            IisHandler iisHandler = new IisHandler();
            EnvironmentHandler envHandler = new EnvironmentHandler();
            ServiceHandler serHandler = new ServiceHandler();
            DatabaseHandler datHandler = new DatabaseHandler();

            // Initialize server manager
            ServerManager server = new ServerManager();

            // Environment:
            EnvironmentData environment = envHandler.GetEnvironmentData();
            string json = JsonConvert.SerializeObject(environment);
            Console.WriteLine(json);



            Version iisVersion = iisHandler.GetIisVersion(environment);

            List<string> values = environment.GetAllValues();

            System.IO.File.WriteAllText(@"C:\Users\Public\JSONEnvironment.txt", json);
            //System.IO.File.WriteAllLines(@"C:\Users\Public\Environment.txt", values);

            // Applications:
            serHandler.LogServices();

            if (environment.hasIis)
            {
                IISData iis = iisHandler.CreateIisDataObject(server, iisVersion);
                iisHandler.StoreIIS(iis);
            }
            //datHandler.LogDatabases();
        }



        }

    }

