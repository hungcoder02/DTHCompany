using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Eproject_MVC.Controllers
{
    public class HomeController : Controller
    {
        private Data db = new Data();
        public ActionResult homepage()
        {
            var packages = db.PackageDetails.Take(4).ToList();

            return View(packages);
        }

        public ActionResult preview(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageDetail packageDetail = db.PackageDetails.Find(id);
            if (packageDetail == null)
            {
                return HttpNotFound();
            }
            return View(packageDetail);
        }

        public ActionResult about()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult contact()
        {
            ViewBag.Message = "";

            return View();
        }
        public ActionResult faq()
        {
            ViewBag.Message = "";

            return View();
        }
        public ActionResult news()
        {
            ViewBag.Message = "";

            return View();
        }
        public ActionResult allmovies()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}