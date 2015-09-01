using Microsoft.Web.Administration;
using ServerSnitch.Handlers;
using ServerSnitch.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
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
        static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();

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
            Version iisVersion = iisHandler.GetIisVersion(environment);

            List<string> values = environment.GetAllValues();
            System.IO.File.WriteAllLines(@"C:\Users\Public\Environment.txt", values);

            // Applications:
            serHandler.LogServices();

            if (environment.hasIis)
            {
                IISData iis = iisHandler.CreateIisDataObject(server, iisVersion);
                iisHandler.logWebsitesAndPools(iis);
            }

            datHandler.LogDatabases();
        }

        //    Console.WriteLine("--------------------------------------------------");
        //    Console.WriteLine("START:");
        //    // FIND DATABASES

        //    // Start with drives if you have to search the entire computer.
        //    List<string> databases = new List<string>();
 

        //    string[] drives = System.Environment.GetLogicalDrives();

        //    foreach (string dr in drives)
        //    {
        //        System.IO.DriveInfo di = new System.IO.DriveInfo(dr);

        //        // Here we skip the drive if it is not ready to be read. This 
        //        // is not necessarily the appropriate action in all scenarios. 
        //        if (!di.IsReady)
        //        {
        //            Console.WriteLine("The drive {0} could not be read", di.Name);
        //            continue;
        //        }
        //        System.IO.DirectoryInfo rootDir = di.RootDirectory;
        //        WalkDirectoryTree(rootDir, databases);
        //    }

        //    // Write out all the files that could not be processed.
        //    Console.WriteLine("Files with restricted access:");
        //    foreach (string s in log)
        //    {
        //        Console.WriteLine(s);
        //    }
        //    // Keep the console window open in debug mode.
        //    System.IO.File.WriteAllLines(@"C:\Users\Public\Databases.txt", databases);



           
        //    }

        //static void WalkDirectoryTree(System.IO.DirectoryInfo root, List<string> databases)
        //{
        //    System.IO.FileInfo[] files = null;
        //    System.IO.DirectoryInfo[] subDirs = null;

        //    // First, process all the files directly under this folder 
        //    try
        //    {
        //        files = root.GetFiles("*.mdf*");
        //    }
        //    // This is thrown if even one of the files requires permissions greater 
        //    // than the application provides. 
        //    catch (UnauthorizedAccessException e)
        //    {
        //        // This code just writes out the message and continues to recurse. 
        //        // You may decide to do something different here. For example, you 
        //        // can try to elevate your privileges and access the file again.
        //        log.Add(e.Message);
        //    }

        //    catch (System.IO.DirectoryNotFoundException e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }

        //    if (files != null)
        //    {
        //        foreach (System.IO.FileInfo fi in files)
        //        {
        //            // In this example, we only access the existing FileInfo object. If we 
        //            // want to open, delete or modify the file, then 
        //            // a try-catch block is required here to handle the case 
        //            // where the file has been deleted since the call to TraverseTree().
        //            Console.WriteLine(fi.FullName);
        //            Console.WriteLine(fi.Name);
        //            databases.Add(fi.Name);


                    
        //        }

        //        // Now find all the subdirectories under this directory.
        //        subDirs = root.GetDirectories();

        //        foreach (System.IO.DirectoryInfo dirInfo in subDirs)
        //        {
        //            // Resursive call for each subdirectory.
        //            WalkDirectoryTree(dirInfo, databases);
        //        }
        //    }
        //}


        }

    }

