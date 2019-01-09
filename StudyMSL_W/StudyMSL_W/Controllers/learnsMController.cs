using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudyMSL_W.Models;

namespace StudyMSL_W.Controllers
{
    public class learnsMController : Controller
    {
        private studymsl_dbEntities db = new studymsl_dbEntities();

        // GET: learnsM
        public ActionResult Index()
        {
            return View(db.learns.ToList());
        }

        // GET: learnsM/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            learn learn = db.learns.Find(id);
            if (learn == null)
            {
                return HttpNotFound();
            }
            return View(learn);
        }

        // GET: learnsM/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: learnsM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "image_id,image_type,image_name,image_name_malay,image_dir,image_desc,image_desc_malay")] learn learn)
        {
            if (ModelState.IsValid)
            {
                db.learns.Add(learn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(learn);
        }

        // GET: learnsM/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            learn learn = db.learns.Find(id);
            if (learn == null)
            {
                return HttpNotFound();
            }
            return View(learn);
        }

        // POST: learnsM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "image_id,image_type,image_name,image_name_malay,image_dir,image_desc,image_desc_malay")] learn learn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(learn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(learn);
        }

        // GET: learnsM/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            learn learn = db.learns.Find(id);
            if (learn == null)
            {
                return HttpNotFound();
            }
            return View(learn);
        }

        // POST: learnsM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            learn learn = db.learns.Find(id);
            db.learns.Remove(learn);
            db.SaveChanges();
            return RedirectToAction("Index");
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
