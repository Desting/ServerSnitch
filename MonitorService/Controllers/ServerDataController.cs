﻿using DataExtractor.Model;
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
                    
                    db.Servers.Add(content);
                    
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


    }


}
