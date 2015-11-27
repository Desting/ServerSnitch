using Atea.Dbs.ServerMonitor.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Text;
using ServerModel;

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
                    .ToList();
                return View(result);
            }


        }

        public ActionResult CreateNewTag(string title)
        {
            Tag newTag = new Tag(title);

            using (var db = new ServerDb())
            {
            var old = db.Tags.Where(m => m.title == newTag.title)
                    .FirstOrDefault();

                // Save Existing
            if (old != null)
            {
                db.Tags.Remove(old);
                db.Tags.Add(newTag);
            }
                // Save New
            else
            {
                db.Tags.Add(newTag);

            }


            db.SaveChanges();
            }
            return PartialView(newTag);

        }

    }
}
