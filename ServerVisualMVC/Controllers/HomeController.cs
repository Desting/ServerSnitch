using Atea.Dbs.ServerMonitor.DataAccess;
using DataExtractor.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServerVisualMVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Entities()
        {
            using (var db = new ServerDb())
            {
                var result = db.Servers
                    .Include(m => m.services)
                    .Include("applications.dependencies")
                    .ToList();

                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public List<MasterEntity> Servers()
        {
            using (var db = new ServerDb())
            {
                var result = db.Servers
                    .Include(m => m.services)
                    .Include("applications.dependencies")
                    .ToList();

                return result;
            }
        }
    }
}
