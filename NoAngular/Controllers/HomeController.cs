using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoAngular.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "The place for you to view some servers";

            return View();
        }

        public ActionResult Owners()
        {
            ViewBag.Message = "This is a very nice description page of our ServerMonitor application";

            return View();
        }

        public ActionResult Tags()
        {
            ViewBag.Message = "My information";

            return View();
        }
    }
}
