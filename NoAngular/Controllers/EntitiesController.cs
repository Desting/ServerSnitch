using Atea.Dbs.ServerMonitor.DataAccess;
using DataExtractor.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoAngular.Controllers
{
    public class EntitiesController : Controller
    {
        //
        // GET: /Entities/
        [HttpGet]
        public ActionResult Index()
        {
            using (var db = new ServerDb())
            {
                var result = db.Servers
                    .Include(m => m.services)
                    .Include(m => m.environment)
                    .Include(m => m.owner)
                    .Include("services.dependencies")
                    .OrderByDescending(m => m.Id)
                    .Skip(0)
                    .Take(50)
                    .ToList();
                return PartialView(result);
            }
        }

        public ActionResult Details(string id)
        {
            using (var db = new ServerDb())
            {
                var result = db.Servers
                    .Include(m => m.environment)
                    .Include(m => m.services)
                    .Include(m => m.iis)
                    .Include("iis.websites.applicationPools")

                    .Where(m => m.Id == id)
                    .FirstOrDefault();
                return View(result);
            }
        }



    }
}
