using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServerVisualMVC.Controllers
{
    public class PagesController : Controller
    {
        //
        // GET: /Pages/

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


    }
}
