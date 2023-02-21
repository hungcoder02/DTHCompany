using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Database;

namespace Eproject_MVC.Controllers
{
    public class PackageDetailsController : Controller
    {
        private Data db = new Data();

        // GET: PackageDetails
        public ActionResult packagetable()
        {
            var packageDetails = db.PackageDetails.Include(p => p.DnD);
            return View(packageDetails.ToList());
        }

        // GET: PackageDetails/Details/5
        public ActionResult Details(int? id)
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

        // GET: PackageDetails/Create
        public ActionResult Create()
        {
            ViewBag.DnDId = new SelectList(db.DnDs, "DnDId", "DnDname");
            return View();
        }

        // POST: PackageDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PackageId,Packagename,Price,Descrip,Img,DnDId,File")] PackageDetail packageDetail)
        {
            string fileName = Path.GetFileName(packageDetail.File.FileName);
            string _fileName = DateTime.Now.ToString("hhmmssfff") + fileName;
            string path = Path.Combine(Server.MapPath("../Image/"), _fileName);
            packageDetail.Img = "../Image/" + _fileName;
            db.PackageDetails.Add(packageDetail);
            if (db.SaveChanges() > 0)
            {
                packageDetail.File.SaveAs(path);
            }
            return RedirectToAction("packagetable");

#pragma warning disable CS0162 // Unreachable code detected
            ViewBag.DnDId = new SelectList(db.DnDs, "DnDId", "DnDname", packageDetail.DnDId);
#pragma warning restore CS0162 // Unreachable code detected
            return View(packageDetail);
        }

        // GET: PackageDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageDetail packageDetail = db.PackageDetails.Find(id);
            Session["imgPath"] = packageDetail.Img;
            if (packageDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.DnDId = new SelectList(db.DnDs, "DnDId", "DnDname", packageDetail.DnDId);
            return View(packageDetail);
        }

        // POST: PackageDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PackageId,Packagename,Price,Descrip,Img,DnDId,File")] PackageDetail packageDetail)
        {

            if (packageDetail.File != null)
            {
                string fileName = Path.GetFileName(packageDetail.File.FileName);
                string _fileName = DateTime.Now.ToString("hhmmssfff") + fileName;
                string extension = Path.GetExtension(packageDetail.File.FileName);
                string path = Path.Combine(Server.MapPath("~/Image/"), _fileName);
                packageDetail.Img = "~/Image/" + _fileName;
                db.Entry(packageDetail).State = EntityState.Modified;

                if (db.SaveChanges() > 0)
                {

                    packageDetail.File.SaveAs(path);
                    ModelState.Clear();


                }
                return RedirectToAction("packagetable");
            }
            else
            {
                packageDetail.Img = Session["imgPath"].ToString();
                db.Entry(packageDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("packagetable");
            }
#pragma warning disable CS0162 // Unreachable code detected
            ViewBag.DnDId = new SelectList(db.DnDs, "DnDId", "DnDname", packageDetail.DnDId);
#pragma warning restore CS0162 // Unreachable code detected
            return View(packageDetail);
        }

        // GET: PackageDetails/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: PackageDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PackageDetail packageDetail = db.PackageDetails.Find(id);
            db.PackageDetails.Remove(packageDetail);
            db.SaveChanges();
            return RedirectToAction("packagetable");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
