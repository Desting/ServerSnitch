using DataExtractor.Model;
using Atea.Dbs.ServerMonitor.DataAccess;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
                db.Servers.Add(content);
                db.SaveChanges();
            }

            return Request.CreateResponse(HttpStatusCode.OK, "OK");
        }

    }


}
