using Atea.Dbs.ServerMonitor.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoAngular.Controllers
{
    public class TagsController : Controller
    {
        //
        // GET: /Tags/

        public ActionResult Index()
        {
            using (var db = new ServerDb())
            {
                var result = db.Tags
                    .Include()
            }


            return View();
        }

    }
}
