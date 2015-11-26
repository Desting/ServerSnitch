using DataExtractor.Model;
using Atea.Dbs.ServerMonitor.DataAccess;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using DataExtractor.Model.IIS;
using ServerModel;

namespace MonitorService.Controllers
{
    public class ServerDataController : ApiController
    {

        public object Post([FromBody] MasterEntity content)
        {
            var json = this.Request.Content.ReadAsStringAsync().Result;
            Console.WriteLine(json);

            using (var db = new ServerDb()) 
            {
                // Check if the server already exists in the DB
                var old = db.Servers.Where(m => m.Id == content.Id)
                    .Include(m => m.environment)
                    .Include(m => m.iis)
                    .FirstOrDefault();

                // Save Existing Server
                if (old != null)
                {
                    db.Servers.Remove(old);
                    content.cost = 300;
                    content.SLA = "Bronze";

                    ICollection<Tag> tags = new List<Tag>();
                    Tag tag = new Tag("Navision");
                    Tag tag2 = new Tag("Service One");
                    tags.Add(tag);
                    tags.Add(tag2);

                    //Owner owner = new Owner("Nizi", "Nikolaj Desting", "nizi@lala.dk");


                    //content.tags = tags;
                    //content.owner = owner;

                    ICollection<MasterEntity> servers = new List<MasterEntity>();
                    servers.Add(content);
                    //db.SaveChanges();

                    db.Servers.Add(content);
                    

                    //// ENVIRONMENT
                    //old.environment.hasIis = content.environment.hasIis;
                    //old.environment.osVersion = content.environment.osVersion;
                    //old.environment.userName = content.environment.userName;
                    //old.environment.logTime = content.environment.logTime;
                    //old.environment.domainName = content.environment.domainName;

                    //// IIS
                    //old.iis.IISVersion = content.iis.IISVersion;

                    ////List<Website> updatedSites = new List<Website>();
                    //foreach (var site in content.iis.websites) 
                    //{
                    //    // Check if the site already exists for this server
                    //    var existingSite = old.iis.websites.Where(m => m.siteName == site.siteName).FirstOrDefault();

                    //    // Save Existing Site
                    //    if (existingSite != null)
                    //    {
                    //        existingSite.siteName = site.siteName;
                    //        existingSite.state = site.state;
                    //        existingSite.parentPool = site.parentPool;
                    //        foreach (var pool in site.applicationPools) 
                    //        {
                    //            var existingPool = existingSite.applicationPools.Where(p => p.Id == pool.Id).FirstOrDefault();

                    //            // Save Existing Pool
                    //            if (existingPool != null)
                    //            {
                    //                existingPool.poolName = pool.poolName;
                    //            }
                    //            // Save New Pool
                    //            else 
                    //            {
                    //                existingSite.applicationPools.Add(existingPool);
                    //            }
                    //        }
                    //    }
                            // Save New Site
                    //    else 
                    //    {
                    //        old.iis.websites.Add(existingSite);
                    //    }
                    //}

                    //// SERVICES
                    //foreach (var application in content.applications)
                    //{
                    //    // Check if the service already exists for this server
                    //    var existingApp = old.applications.Where(a => a.systemName == application.systemName).FirstOrDefault();

                    //    // Save Existing Application/Service
                    //    if (existingApp != null)
                    //    {
                    //        existingApp.displayName = application.displayName;
                    //        existingApp.description = application.description;
                    //        existingApp.logon = application.logon;
                    //        existingApp.status = application.status;
                    //        existingApp.type = application.type;
                    //    }
                    //    else 
                    //    {
                    //        old.applications.Add(existingApp);
                    //    }
                    //}

                    //db.Servers.Attach(content);
                    //db.Entry(content).State = EntityState.Modified;
                    db.SaveChanges();
                }
                    // Save New Server
                else {
                    db.Servers.Add(content);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException e)
                    {
                        throw;
                    } 
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, "OK");
        }

        //[HttpPut]
        //public object Update([FromBody] MasterEntity updatedServer)
        //{

        //    using (var db = new ServerDb())
        //    {
        //        var original = db.Servers.Find(updatedServer.Id);

        //        if (original != null)
        //        {
        //            db.Entry(original).CurrentValues.SetValues(updatedServer);
        //            db.SaveChanges();
        //        }
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, "OK");

        //}

    }


}
