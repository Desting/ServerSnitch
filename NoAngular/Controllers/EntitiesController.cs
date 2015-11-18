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
        // GET: /Api/
        [HttpGet]
        public ActionResult Index()
        {
            using (var db = new ServerDb())
            {
                var result = db.Servers
                    .Include(m => m.applications)
                    .Include("applications.dependencies")
                    .OrderByDescending(m => m.Id)
                    .Skip(0)
                    .Take(50)
                    .ToList();
                return PartialView(result);
            }
        }

        public ActionResult Details(int id) 
        {
            using (var db = new ServerDb())
            {
                var result = db.Servers
                    .Include(m => m.applications)
                    .Include(m => m.iis)
                    .Include("iis.websites.applicationPools")

                    .Where(m => m.Id == id)
                    .FirstOrDefault();
                return View(result);
            }
        }


        // Currently not used
        public ActionResult Services(int id)
        {
            using (var db = new ServerDb())
            {
                var result = db.Servers
                    .Include(m => m.applications)
                    .Include("applications.dependencies")
                    .Where(m => m.Id == id)
                    .FirstOrDefault();
                return PartialView(result);
            }
        }

        public ActionResult Iis(int id)
        {
            using (var db = new ServerDb())
            {
                var result = db.Servers
                    .Include(m => m.iis)
                    .Include("iis.websites")
                    .Where(m => m.Id == id)
                    .FirstOrDefault();
                return PartialView(result);
            }
        }
    }
}
