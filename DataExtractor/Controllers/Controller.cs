using Microsoft.Web.Administration;
using Newtonsoft.Json;
using DataExtractor.Handlers;
using DataExtractor.Model;
using DataExtractor.Model.IIS;
using DataExtractor.Parser;
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
using System.Net;
using System.Runtime.Serialization;
using System.Net.Http;

namespace DataExtractor.Controllers
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

            // Save Environment to MasterEntity
            dataStorage.environment = environment;

            // IIS:
            if (environment.hasIis)
            {
                IISData iis = iisHandler.CreateIisDataObject(server, iisVersion);
                IISStringContainer iisContainer = iisHandler.StoreIIS(iis);

                // Save IIS to MasterEntity
                dataStorage.iis = iisContainer;
                
            }

            // Applications:
            List<ServiceData> applications = serHandler.ListServices();

            // Save Applications to MasterEntity
            dataStorage.applications = applications;

            
            // Databases:
            //List<string> databases = datHandler.ListDatabases();
            //dataStorage.databases = databases;

            

            // Serialize to JSON
            JSONParser parser = new JSONParser();
            string json = parser.SerializeObject(dataStorage);

            // Save to file
            //string path = @"C:\Users\Public\JSONMaster.txt";
            //parser.SaveToFile(path, json);


            // HTTP POST
            HTTPHandler http = new HTTPHandler();
            
            // this is where we will send it
            string uri = "http://localhost:62273/api/ServerData";
            http.PostMasterEntity(uri, json);



        }




        }

    }

