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

        [HttpGet]
        public ActionResult Servers()
        {
            using (var db = new ServerDb())
            {
                var result = db.Servers
                    .Include(m => m.applications)
                    .Include("applications.dependencies")
                    .ToList();

                return View(result);
            }
        }
    }
}
