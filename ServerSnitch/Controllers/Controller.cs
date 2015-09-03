using Microsoft.Web.Administration;
using Newtonsoft.Json;
using ServerSnitch.Handlers;
using ServerSnitch.Model;
using ServerSnitch.Model.IIS;
using ServerSnitch.Parser;
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

        
        public void ExtractAndSerializeData()
        {
            // Initialize MasterEntity to hold data
            MasterEntity dataStorage = new MasterEntity();


            // Initialize handlers
            EnvironmentHandler envHandler = new EnvironmentHandler();
            IisHandler iisHandler = new IisHandler();
            ServiceHandler serHandler = new ServiceHandler();
            DatabaseHandler datHandler = new DatabaseHandler();

            // Initialize server manager
            ServerManager server = new ServerManager();

            // Environment:
            EnvironmentData environment = envHandler.GetEnvironmentData();

            // Check for IIS:
            Version iisVersion = iisHandler.GetIisVersion(environment);
            dataStorage.environment = environment;

            // IIS:
            if (environment.hasIis)
            {
                IISData iis = iisHandler.CreateIisDataObject(server, iisVersion);
                IISStringContainer iisContainer = iisHandler.StoreIIS(iis);
                dataStorage.iis = iisContainer;
                
            }

            // Applications:
            List<ServiceData> applications = serHandler.ListServices();
            dataStorage.applications = applications;

            
            // Databases:
            //List<string> databases = datHandler.ListDatabases();
            //dataStorage.databases = databases;
            

            // Serialize to JSON
            JSONParser parser = new JSONParser();
            string envJson = parser.SerializeObject(dataStorage);

            // Save to file
            string path = @"C:\Users\Public\JSONMaster.txt";
            parser.SaveToFile(path, envJson);

        }



        }

    }

