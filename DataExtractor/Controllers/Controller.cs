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
    public class Controller
    {
        private string uri;
        private IEnvironmentHandler envHandler = new EnvironmentHandler();
        private IIisHandler iisHandler = new IisHandler();
        private IServiceHandler serHandler = new ServiceHandler();

        public Controller(string uri)
        {
            this.uri = uri;
        }

        public Controller(string uri, IEnvironmentHandler envHandler, IIisHandler iisHandler, IServiceHandler serHandler)
            : this(uri)
        {
            this.envHandler = envHandler;
            this.iisHandler = iisHandler;
            this.serHandler = serHandler;
        }
        public void ExtractAndSerializeData()
        {
            // Initialize MasterEntity to hold data
            MasterEntity dataStorage = GetData();

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
            http.PostMasterEntity(uri, json);



        }

        public MasterEntity GetData()
        {
            MasterEntity dataStorage = new MasterEntity();

            // Environment:
            EnvironmentData environment = envHandler.GetEnvironmentData();

            // Check for IIS:
            Version iisVersion = iisHandler.GetIisVersion();
            environment.hasIis = iisVersion !=null ;

            // Save Environment to MasterEntity
            dataStorage.environment = environment;

            // IIS:
            if (environment.hasIis)
            {
                IISData iis = iisHandler.CreateIisDataObject(iisVersion);
                IISStringContainer iisContainer = iisHandler.StoreIIS(iis);

                // Save IIS to MasterEntity
                dataStorage.iis = iisContainer;

            }

            // Applications:
            dataStorage.applications = serHandler.ListServices(); // Test!!

            return dataStorage;
        }




        }

    }

