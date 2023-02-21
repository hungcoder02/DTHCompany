using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Database;

namespace Eproject_MVC.Controllers
{
    public class DnDsController : Controller
    {
        private Data db = new Data();

        // GET: DnDs
        public ActionResult dndtable()
        {
            return View(db.DnDs.ToList());
        }

        // GET: DnDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DnD dnD = db.DnDs.Find(id);
            if (dnD == null)
            {
                return HttpNotFound();
            }
            return View(dnD);
        }

        // GET: DnDs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DnDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DnDId,DnDname,Password,payment")] DnD dnD)
        {
            if (ModelState.IsValid)
            {
                db.DnDs.Add(dnD);
                db.SaveChanges();
                return RedirectToAction("dndtable");
            }

            return View(dnD);
        }

        // GET: DnDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DnD dnD = db.DnDs.Find(id);
            if (dnD == null)
            {
                return HttpNotFound();
            }
            return View(dnD);
        }

        // POST: DnDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DnDId,DnDname,Password,payment")] DnD dnD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dnD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("dndtable");
            }
            return View(dnD);
        }

        // GET: DnDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DnD dnD = db.DnDs.Find(id);
            if (dnD == null)
            {
                return HttpNotFound();
            }
            return View(dnD);
        }

        // POST: DnDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DnD dnD = db.DnDs.Find(id);
            db.DnDs.Remove(dnD);
            db.SaveChanges();
            return RedirectToAction("dndtable");
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
